using AoC2022Days.DayHelpers.Day05;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day05
{
    [TestFixture]
    public class ShipTest
    {
        List<string> inputs = new List<string>()
            {
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 "
            };
        [Test]
        public void Ctor_WithTestInput_ShouldFillCorrectStacks()
        {
            var ship = new Ship(inputs);

            Assert.AreEqual('N', ship.Stacks[0][0]);
            Assert.AreEqual('Z', ship.Stacks[0][1]);
            Assert.AreEqual('D', ship.Stacks[1][0]);
            Assert.AreEqual('C', ship.Stacks[1][1]);
            Assert.AreEqual('M', ship.Stacks[1][2]);
            Assert.AreEqual('P', ship.Stacks[2][0]);
        }

        [Test]
        public void Move9000_WithGivenProcedure_ShouldMoveCorrectCrate()
        {
            var ship = new Ship(inputs);
            var procedure = new Procedure("move 1 from 2 to 1");

            ship.MoveCrateMover9000(procedure);

            Assert.AreEqual('D', ship.Stacks[0][0]);
            Assert.AreEqual('N', ship.Stacks[0][1]);
            Assert.AreEqual('Z', ship.Stacks[0][2]);
            Assert.AreEqual('C', ship.Stacks[1][0]);
            Assert.AreEqual('M', ship.Stacks[1][1]);
            Assert.AreEqual('P', ship.Stacks[2][0]);
        }
        [Test]
        public void Move9001_WithGivenProcedure_ShouldMoveCorrectCrate()
        {
            var ship = new Ship(inputs);
            var procedure = new Procedure("move 1 from 2 to 1");

            ship.MoveCrateMover9001(procedure);

            Assert.AreEqual('D', ship.Stacks[0][0]);
            Assert.AreEqual('N', ship.Stacks[0][1]);
            Assert.AreEqual('Z', ship.Stacks[0][2]);
            Assert.AreEqual('C', ship.Stacks[1][0]);
            Assert.AreEqual('M', ship.Stacks[1][1]);
            Assert.AreEqual('P', ship.Stacks[2][0]);
        }
        [Test]
        public void Move9001_WithAllTestProcedures_ShouldMoveCorrectCrate()
        {
            var ship = new Ship(inputs);
            List<Procedure> procedures = new List<Procedure>()
            {
                new Procedure("move 1 from 2 to 1"),
                new Procedure("move 3 from 1 to 3"),
                new Procedure("move 2 from 2 to 1"),
                new Procedure("move 1 from 1 to 2"),
            };

            foreach(var proc in procedures)
            {
                ship.MoveCrateMover9001(proc);
            }

            Assert.AreEqual('M', ship.Stacks[0][0]);
            Assert.AreEqual('C', ship.Stacks[1][0]);
            Assert.AreEqual('D', ship.Stacks[2][0]);
            Assert.AreEqual('N', ship.Stacks[2][1]);
            Assert.AreEqual('Z', ship.Stacks[2][2]);
            Assert.AreEqual('P', ship.Stacks[2][3]);
        }
        [Test]
        public void GetTopOfStacks_WithAllTestProcedures_ShouldReturnCorrectValue()
        {
            var ship = new Ship(inputs);
            List<Procedure> procedures = new List<Procedure>()
            {
                new Procedure("move 1 from 2 to 1"),
                new Procedure("move 3 from 1 to 3"),
                new Procedure("move 2 from 2 to 1"),
                new Procedure("move 1 from 1 to 2"),
            };

            foreach (var proc in procedures)
            {
                ship.MoveCrateMover9000(proc);
            }

            Assert.AreEqual("CMZ", ship.GetTopOfStacks());
        }
    }
}
