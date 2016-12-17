using System;
using AdvancedWorld;
using AdvancedWorld.Creatures;
using AdvancedWorld.Exceptions;
using AdvancedWorld.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedWorldTests
{
    [TestClass]
    public class AdvancedGodTests
    {
        private static readonly AdvancedGod God = new AdvancedGod();
        private readonly Human _girl = God.MakeGirl(Sex.Female);
        private readonly Human _smartGirl = God.MakeSmartGirl(Sex.Female);
        private readonly Human _prettyGirl = God.MakePrettyGirl(Sex.Female);
        private readonly Human _student = God.MakeStudent(Sex.Male);
        private readonly Human _botan = God.MakeBotan(Sex.Male);

        [TestMethod]
        public void GirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_girl, _student));
                    if (child == null) continue;
                    Assert.IsTrue(child is Girl);
                    Assert.AreEqual(((Girl)child).Patronymic, Names.PatronymicFromParentName(Sex.Female, _student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void GirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_girl, _botan));
                    if (child == null) continue;
                    Assert.IsTrue(child is SmartGirl);
                    Assert.AreEqual(((SmartGirl)child).Patronymic,
                        Names.PatronymicFromParentName(Sex.Female, _botan.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PrettyGirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_prettyGirl, _student));
                    if (child == null) continue;
                    Assert.IsTrue(child is PrettyGirl);
                    Assert.AreEqual(((PrettyGirl)child).Patronymic, Names.PatronymicFromParentName(Sex.Female, _student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PrettyGirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_prettyGirl, _botan));
                    if (child == null) continue;
                    Assert.IsTrue(child is PrettyGirl);
                    Assert.AreEqual(((PrettyGirl)child).Patronymic, Names.PatronymicFromParentName(Sex.Female, _botan.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SmartGirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_smartGirl, _student));
                    if (child == null) continue;
                    Assert.IsTrue(child is Girl);
                    Assert.AreEqual(((Girl)child).Patronymic, Names.PatronymicFromParentName(Sex.Female, _student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SmartGirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var child = God.DateCouple(new Tuple<Human, Human>(_smartGirl, _botan));
                    if (child == null) continue;
                    Assert.IsTrue(child is Book);
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(WrongCoupleException))]
        public void HomosexualCoupleTest()
        {
            var child = God.DateCouple(new Tuple<Human, Human>(_girl, _smartGirl));
        }
    }
}