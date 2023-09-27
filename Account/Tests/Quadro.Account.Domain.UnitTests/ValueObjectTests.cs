using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain.UnitTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            var valueObject1 = new TestValueObject("1", "2");
            var valueObject2 = new TestValueObject("1", "2");
            Assert.True(valueObject1.Equals(valueObject2));
        }
        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            var valueObject1 = new TestValueObject("1", "2");
            var valueObject2 = new TestValueObject("1", "1");
            Assert.False(valueObject1.Equals(valueObject2));
        }

        [Fact]
        public void Equals_NullParameter_ReturnsFalse()
        {
            var valueObject1 = new TestValueObject("1", "2");
            Assert.False(valueObject1.Equals(null));
        }

        [Fact]
        public void GetHashCode_SameValues_ReturnsSameValue()
        {
            var valueObject1 = new TestValueObject("1", "2");
            var valueObject2 = new TestValueObject("1", "2");
            Assert.True(valueObject1.GetHashCode().Equals(valueObject2.GetHashCode()));
        }

        [Fact]
        public void GetHashCode_DifferentValues_ReturnsDifferentValue()
        {
            var valueObject1 = new TestValueObject("1", "2");
            var valueObject2 = new TestValueObject("1", "1");
            Assert.False(valueObject1.GetHashCode().Equals(valueObject2.GetHashCode()));
        }

        [Fact]
        public void EqualOperator_LeftOperandNull_ReturnsFalse()
        {
            TestValueObject nullValueObject = null;
            var valueObjectRight = new TestValueObject("1", "2");
            Assert.False(nullValueObject == valueObjectRight);
        }

        [Fact]
        public void EqualOperator_RightOperandNull_ReturnsFalse()
        {
            var valueObjectLeft = new TestValueObject("1", "2");
            TestValueObject nullValueObject = null;
            Assert.False(valueObjectLeft == nullValueObject);
        }

        [Fact]
        public void EqualOperator_SameValues_ReturnsTrue()
        {
            var valueObjectLeft = new TestValueObject("1", "2");
            var valueObjectRight = new TestValueObject("1", "2");
            Assert.True(valueObjectLeft == valueObjectRight);
        }

        [Fact]
        public void NotEqualOperator_LeftOperandNull_ReturnsTrue()
        {
            TestValueObject nullValueObject = null;
            var valueObjectRight = new TestValueObject("1", "2");
            Assert.True(nullValueObject != valueObjectRight);
        }

        [Fact]
        public void NotEqualOperator_RightOperandNull_ReturnsTrue()
        {
            var valueObjectLeft = new TestValueObject("1", "2");
            TestValueObject nullValueObject = null;
            Assert.True(valueObjectLeft != nullValueObject);
        }

        [Fact]
        public void NotEqualOperator_SameValues_ReturnsFalse()
        {
            var valueObjectLeft = new TestValueObject("1", "2");
            var valueObjectRight = new TestValueObject("1", "2");
            Assert.False(valueObjectLeft != valueObjectRight);
        }


    }

    public class TestValueObject : ValueObject
    {
        public string Prop1 { get; }
        public string Prop2 { get; }

        public TestValueObject(string prop1, string prop2)
        {
            Prop1 = prop1;
            Prop2 = prop2;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Prop1;
            yield return Prop2;
        }
    }
}
