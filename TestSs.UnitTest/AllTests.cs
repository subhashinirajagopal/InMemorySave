using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSs.UnitTest
{
    [TestClass]
    public class AllTests
    {
        private IRepository<IStoreable> _repository;
        private IStoreable _firstItem = new Storeable { Id = 1, Name = "FirstItem" };
        private IStoreable _secondItem = new Storeable { Id = 2, Name = "SecondItem" };
        private IStoreable _thirdItem = new Storeable { Id = 3, Name = "ThirdItem" };

        public AllTests() : this(new Repository<IStoreable>()) { }

        public AllTests(IRepository<IStoreable> repository)
        {
            _repository = repository;
        }

        [TestMethod]
        public void GetById_Test()
        {
            _repository.Save(_secondItem);
            _repository.Save(_firstItem);
            var actual = _repository.FindById(2);
            Assert.AreEqual(_secondItem, actual);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            _repository.Save(_firstItem);
            _repository.Save(_secondItem);
            _repository.Save(_thirdItem);
            var actual = _repository.All();
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<IStoreable>));
            Assert.IsTrue(actual.Count()==3);
        }

        [TestMethod]
        public void Save_Test()
        {
            _repository.Save(_firstItem);
            _repository.Save(_secondItem);
            var actual = _repository.All();
            Assert.IsTrue(actual.Count() == 2);
            Assert.IsTrue(actual.Contains(_firstItem));
            Assert.IsTrue(actual.Contains(_secondItem));
        }

        [TestMethod]
        public void Update_Test()
        {
            _repository.Save(_firstItem);
            var updatedFirstItem = new Storeable { Id = 1, Name = "UpdatedFirstItem" };
            _repository.Update(1, updatedFirstItem);

            var actual = _repository.All();
            Assert.IsTrue(actual.Count() == 1);
            Assert.IsTrue(actual.First().Id == updatedFirstItem.Id);
            Assert.IsTrue(actual.First().Name == updatedFirstItem.Name);
        }

        [TestMethod]
        public void Delete_Test()
        {
            _repository.Save(_firstItem);
            _repository.Save(_secondItem);
            _repository.Save(_thirdItem);
            _repository.Delete(1);
            _repository.Delete(2);
            _repository.Delete(3);
            var actual = _repository.All();
            Assert.IsFalse(actual.Contains(_firstItem));
            Assert.IsFalse(actual.Contains(_secondItem));
            Assert.IsFalse(actual.Contains(_thirdItem));
            Assert.IsTrue(actual.Count() == 0);
        }
    }
}
