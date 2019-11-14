using NUnit.Framework;
using FluentAssertions;

using Starter.Framework.Extensions;

namespace Starter.Tests.Extensions
{
    /// <summary>
    /// Contains tests for the StringExtensions class
    /// </summary>
    [TestFixture]
    public class StringExtensionsTests : TestsBase
    {
        [Test]
        public void Strings_Should_Not_Be_Equal()
        {
            "Ben".IsEqualTo("Dan").Should().BeFalse();
        }

        [Test]
        public void Strings_Should_Be_Equal()
        {
            "Ben".IsEqualTo("Ben").Should().BeTrue();
        }

        [Test]
        public void Different_Case_Strings_Should_Be_Equal()
        {
            "wolverine".IsEqualTo("WOLVERINE").Should().BeTrue();
        }

        [Test]
        public void String_Should_Not_Be_Equal_To_Null()
        {
            "Dan".IsEqualTo(null).Should().BeFalse();
        }

        [Test]
        public void String_Should_Not_Be_Empty()
        {
            "Ben".IsEmpty().Should().BeFalse();
        }

        [Test]
        public void String_Should_Be_Empty()
        {
            "".IsEmpty().Should().BeTrue();
        }

        [Test]
        public void White_Space_String_Should_Be_Empty()
        {
            "     ".IsEmpty().Should().BeTrue();
        }
    }
}