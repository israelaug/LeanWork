using System;
using LeanWorkProject.Models;
using Xunit;

namespace LeanWork.Tests
{
    public class CardTest
    {
        [Trait("Category", "Card"), Trait("Categoria", "Models")]
        [Fact(DisplayName = "Criar cartão com sucesso")]
        public void Criar_cartao_com_sucesso()
        {
            //Arrange && Act
            var testObject = new Card();

            //Assert
            Assert.True(testObject != null);
        }

        [Trait("Category", "Card"), Trait("Categoria", "Models")]
        [Fact(DisplayName = "Validar cartão com sucesso")]
        public void Validar_cartao_com_sucesso()
        {
            //Arrange
            var testObject = TestObject();

            //Act
            var result = testObject.Validate();

            //Assert
            Assert.True(testObject.Valid);
            Assert.True(result);
        }


        [Trait("Category", "Card"), Trait("Categoria", "Models")]
        [Fact(DisplayName = "Validar cartão falha bandeira inválida")]
        public void Validar_cartao_com_falha_bandeira_invalida()
        {
            //Arrange
            var testObject = TestObject(validFlag: false);

            //Act
            var result = testObject.Validate();

            //Assert
            Assert.True(testObject.CardFlag.Length != 10);
            Assert.False(testObject.Valid);
            Assert.False(result);
        }

        [Trait("Category", "Card"), Trait("Categoria", "Models")]
        [Fact(DisplayName = "Validar cartão falha número inválido")]
        public void Validar_cartao_com_falha_numero_invalido()
        {
            //Arrange
            var testObject = TestObject(validNumber: false);

            //Act
            var result = testObject.Validate();

            //Assert
            Assert.True(testObject.Number.Length != 19);
            Assert.False(testObject.Valid);
            Assert.False(result);
        }

        # region Generic Operations
        private Card TestObject(bool validFlag = true, bool validNumber = true)
        {
            Card testObject = new Card();
            testObject.Number = validNumber ? "5142 9978 9179 3601" : "142 9978 9179 3601";
            testObject.CardFlag = validFlag ? "mastercard" : "elo";
            testObject.OwnerName = "Dono do Cartão";
            testObject.ExpiringDate = "06/2019";

            return testObject;
        }

        #endregion
    }
}

