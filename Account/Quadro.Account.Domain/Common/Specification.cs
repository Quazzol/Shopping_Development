using System.Linq.Expressions;
using Ardalis.GuardClauses;

namespace Quadro.Account.Domain.Common
{

    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression { get; }

        public bool IsSatisfiedBy(T entity)
        {
            Guard.Against.Null(Expression);
            var predicate = Expression.Compile();
            return predicate(entity);
        }

        public static Specification<T> operator &(Specification<T> leftSpecification, Specification<T> rightSpecification)
        {
            return new AndSpecification<T>(leftSpecification, rightSpecification);
        }

        public static Specification<T> operator |(Specification<T> leftSpecification, Specification<T> rightSpecification)
        {
            return new OrSpecification<T>(leftSpecification, rightSpecification);
        }

        public static Specification<T> operator !(Specification<T> specification)
        {
            return  new NotSpecification<T>(specification);
        }

    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpecification;
        private readonly Specification<T> _rightSpecification;

        public AndSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get
            {
                var leftExpression = _leftSpecification.Expression;
                var rightExpression = _rightSpecification.Expression;

                var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));

                var leftVisitor = new ReplaceExpressionVisitor(leftExpression.Parameters[0], parameter);
                var left = leftVisitor.Visit(leftExpression.Body);

                var rightVisitor = new ReplaceExpressionVisitor(rightExpression.Parameters[0], parameter);
                var right = rightVisitor.Visit(rightExpression.Body);

                return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                    System.Linq.Expressions.Expression.AndAlso(left, right), parameter);
            }
        }
    }


    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpecification;
        private readonly Specification<T> _rightSpecification;


        public OrSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get
            {
                var leftExpression = _leftSpecification.Expression;
                var rightExpression = _rightSpecification.Expression;

                var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));

                var leftVisitor = new ReplaceExpressionVisitor(leftExpression.Parameters[0], parameter);
                var left = leftVisitor.Visit(leftExpression.Body);

                var rightVisitor = new ReplaceExpressionVisitor(rightExpression.Parameters[0], parameter);
                var right = rightVisitor.Visit(rightExpression.Body);

                return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                    System.Linq.Expressions.Expression.OrElse(left, right), parameter);
            }
        }
    }

    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;


        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get
            {
                var expression = _specification.Expression;
                var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T));
                return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                    System.Linq.Expressions.Expression.Not(expression.Body), parameter);
            }
        }
    }
    
    //Used for parameter replacing
    internal class ReplaceExpressionVisitor
        : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            return node == _oldValue ? _newValue : base.Visit(node);
        }
    }
}
