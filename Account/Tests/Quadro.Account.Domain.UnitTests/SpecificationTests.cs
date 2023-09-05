using System.Linq.Expressions;
using Moq;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain.UnitTests;

public class SpecificationTests
{

    [Fact]
    public void IsSatisfiedBy_NullExpressionGiven_ThrowsArgumentNullException()
    {
        var nullSpecification = new Mock<Specification<TestUser>>();
        var user = new TestUser
        {
            Name = "Name"
        };
        nullSpecification.Setup(q => q.Expression).Returns<Specification<TestUser>>(null);
        Assert.Throws<ArgumentNullException>(() => nullSpecification.Object.IsSatisfiedBy(user));
    }

    [Theory]
    [MemberData(nameof(CompatibleValueAndExpressions))]
    public void IsSatisfiedBy_ExpressionGiven_EvaluatesItAccordingly(string userName, Expression<Func<TestUser, bool>> expression)
    {
        var stubSpecification = new Mock<Specification<TestUser>>();
        var user = new TestUser
        {
            Name = userName
        };
        stubSpecification.Setup(q => q.Expression).Returns(expression);
        Assert.True(stubSpecification.Object.IsSatisfiedBy(user));
    }

    [Theory]
    [MemberData(nameof(CompatibleValueAndExpressions))]
    public void IsSatisfiedBy_NotOperatorUsed_EvaluatesLikeLogicalNot(string userName, Expression<Func<TestUser, bool>> expression)
    {
        var stubSpecification = new Mock<Specification<TestUser>>();
        var user = new TestUser
        {
            Name = userName
        };
        stubSpecification.Setup(q => q.Expression).Returns(expression);
        Assert.False(!(stubSpecification.Object).IsSatisfiedBy(user));

    }

    [Theory]
    [MemberData(nameof(CompatibleValueAndTwoExpressionToMergeWithAnd))]
    public void IsSatisfiedBy_AndOperatorUsed_EvaluatesLikeLogicalAndAlso(string userName, Expression<Func<TestUser, bool>> leftExpression, Expression<Func<TestUser, bool>> rightExpression)
    {
        var leftStubSpecification = new Mock<Specification<TestUser>>();
        leftStubSpecification.Setup(q => q.Expression).Returns(leftExpression);
        var rightStubSpecification = new Mock<Specification<TestUser>>();
        rightStubSpecification.Setup(q => q.Expression).Returns(rightExpression);
        var user = new TestUser
        {
            Name = userName
        };
        var mergedSpecification = leftStubSpecification.Object & rightStubSpecification.Object;
        Assert.True(mergedSpecification.IsSatisfiedBy(user));
    }

    [Theory]
    [MemberData(nameof(CompatibleValueAndTwoExpressionToMergeWithOr))]
    public void IsSatisfiedBy_OrOperatorUsed_EvaluatesLikeLogicalOrElse(string userName, string userSurname, Expression<Func<TestUser, bool>> leftExpression, Expression<Func<TestUser, bool>> rightExpression)
    {
        var leftStubSpecification = new Mock<Specification<TestUser>>();
        leftStubSpecification.Setup(q => q.Expression).Returns(leftExpression);
        var rightStubSpecification = new Mock<Specification<TestUser>>();
        rightStubSpecification.Setup(q => q.Expression).Returns(rightExpression);
        var user = new TestUser
        {
            Name = userName,
            Surname = userSurname
        };
        var mergedSpecification = leftStubSpecification.Object | rightStubSpecification.Object;
        Assert.True(mergedSpecification.IsSatisfiedBy(user));
    }


    public class TestUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }


    public static TheoryData<object, Expression<Func<TestUser, bool>>> CompatibleValueAndExpressions =>
        new()
        {
             { "Name", q=>!string.IsNullOrEmpty(q.Name)},
             { "123456789", q=> q.Name.Length<=10 },
             { "12345", q => q.Name.Length > 4 }
        };

    public static TheoryData<object, Expression<Func<TestUser, bool>>, Expression<Func<TestUser, bool>>> CompatibleValueAndTwoExpressionToMergeWithAnd =>
        new()
        {
            { "BIGNAME", q=>!string.IsNullOrEmpty(q.Name), q=>q.Name.All(char.IsUpper)},
            { "123456789", q=> q.Name.Length<=10 , q=>q.Name.All(char.IsDigit)},
            { "WithoutNumeric", q => q.Name.Length > 4 , q=>q.Name.All(char.IsLetter)}
        };

    public static TheoryData<object, object, Expression<Func<TestUser, bool>>, Expression<Func<TestUser, bool>>> CompatibleValueAndTwoExpressionToMergeWithOr =>
        new()
        {
            { string.Empty,"Surname", q=>!string.IsNullOrEmpty(q.Name),q=> !string.IsNullOrEmpty(q.Surname)},
            { "1234","123455678902", q=> q.Name.Length<=10 ,  q=> q.Surname.Length<=10},
            { "123141231231","1234", q => q.Name.Length > 4 , q => q.Surname.Length > 4}
        };
}