using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePassword;
using System.Threading.Tasks;


namespace OneTimePasswordTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GeneratedPassword()
        {
            IPasswordGenerator passwordGeneratorOne = new PasswordGenerator();
            IPasswordGenerator passwordGeneratorTwo = new PasswordGenerator();

            var passwordOne = passwordGeneratorOne.Generate();
            var passwordTwo = passwordGeneratorTwo.Generate();

            Assert.AreNotEqual(passwordOne, passwordTwo);
        }
        [TestMethod]
        public async Task CreatePassword()
        {
            //Arrange
            IPasswordGenerator passwordGenerator = new PasswordGenerator();

            
            IPasswordManager passwordManager = new PasswordManager(passwordGenerator);
            var passwordOne = passwordManager.CreatePassword("id");
            await Task.Delay(1);
            var passwordTwo = passwordManager.CreatePassword("id");
            var passwordValid = passwordManager.IsPasswordCorrectAndValid("id", passwordOne);

           
            Assert.IsFalse(passwordValid);
            passwordValid = passwordManager.IsPasswordCorrectAndValid("id", passwordTwo);
            Assert.IsTrue(passwordValid);
        }

        [TestMethod]
        public void ValidatePassword()
        {
            
            IPasswordGenerator passwordGenerator = new PasswordGenerator();

            
            IPasswordManager passwordManager = new PasswordManager(passwordGenerator);
            var password = passwordManager.CreatePassword("id");
            var passwordValid = passwordManager.IsPasswordCorrectAndValid("id", password);

          
            Assert.IsTrue(passwordValid);
            passwordValid = passwordManager.IsPasswordCorrectAndValid("id", password);
            Assert.IsFalse(passwordValid);
        }
    }
}
