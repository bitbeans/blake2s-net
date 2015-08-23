using System;
using System.Collections.Generic;
using Blake2s;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Simple Blake2s tests.
    /// TODO: add more tests
    /// </summary>
    [TestFixture]
    public class Blake2sTests
    {
        [Test]
        public void Test()
        {
            var vectors = new List<TestVector>
            {
                new TestVector
                {
                    Id = 1,
                    InputHex = "",
                    KeyHex = "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f",
                    ResultHex = "48a8997da407876b3d79c0d92325ad3b89cbb754d86ab71aee047ad345fd2c49"
                },
                new TestVector
                {
                    Id = 2,
                    InputHex = "00",
                    KeyHex = "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f",
                    ResultHex = "40d15fee7c328830166ac3f918650f807e7e01e177258cdc0a39b11f598066f1"
                },
                new TestVector
                {
                    Id = 3,
                    InputHex = "0001",
                    KeyHex = "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f",
                    ResultHex = "6bb71300644cd3991b26ccd4d274acd1adeab8b1d7914546c1198bbe9fc9d803"
                }
            };


            foreach (var vector in vectors)
            {
                var result = TestHelper.StringToByteArray(vector.ResultHex);
                var hash = Blake2S.Hash(TestHelper.StringToByteArray(vector.InputHex),
                    TestHelper.StringToByteArray(vector.KeyHex), result.Length);
                CollectionAssert.AreEqual(result, hash);
                Console.WriteLine("Test Vector " + vector.Id + ": passed");
            }
        }
    }
}