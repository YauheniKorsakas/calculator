using Calculator.Web.Data;
using Calculator.Web.Data.Models;
using Calculator.Web.Operations.Implementations;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace Calculator.Web.Tests.Operations
{
    [TestFixture]
    public class PlusOperationTests
    {
        private Mock<ICalculatorOperationsRepository> calculatorOperationsRepositoryMock;
        private PlusOperation underTest;

        [SetUp]
        public void Setup() {
            calculatorOperationsRepositoryMock = new Mock<ICalculatorOperationsRepository>();
            underTest = new PlusOperation(calculatorOperationsRepositoryMock.Object);
        }

        [Test]
        public void Constructor_When_CalculatorOperationsRepositoryIsNull_Should_ThrowException() {
            Action act = () => underTest = new PlusOperation(null);

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void Execute_Should_SaveOperationData() {
            var firstOperand = 1;
            var secondOperand = 2;
            var toSave = (CalculatorOperation)null;
            calculatorOperationsRepositoryMock
                .Setup(s => s.Add(It.IsAny<CalculatorOperation>()))
                .Callback<CalculatorOperation>(item => toSave = item);

            underTest.Execute(firstOperand, secondOperand);

            calculatorOperationsRepositoryMock.Verify(s => s.Add(toSave), Times.Once);
            toSave.Should().NotBeNull();
            toSave.FirstOperand.Should().Be(firstOperand);
            toSave.SecondOperand.Should().Be(secondOperand);
            toSave.OperationName.Should().Be(nameof(PlusOperation));
            toSave.OperationResult.Should().Be(firstOperand + secondOperand);
        }

        [Test]
        public void Sum() {
            Assert.AreEqual(1, 2);
        }
    }
}
