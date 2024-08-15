using CustomArray;

namespace CustomArrayTests;

public class ProgramTests
{
    private MyArrayList<int> _arraylist = null!;
    
    [SetUp]
    public void Setup()
    {
        _arraylist = new MyArrayList<int>();
    }

    class Get : ProgramTests
    {
        [Test]
        public void TestGetFunction()
        {
            var arraylist = new MyArrayList<int>(new MyArrayList<int>.Node(3));
            Assert.That(arraylist.Get(0), Is.EqualTo(3));
        }

        [Test]
        public void TestIfGetReturnsIndexValue()
        {
            _arraylist.Add(34);
            _arraylist.Add(11);
            _arraylist.Add(311);
            Assert.That(_arraylist.Get(2), Is.EqualTo(311));
        }

        [Test]
        public void TestIndexOutOfRange()
        {
            _arraylist.Add(39);
            _arraylist.Add(32);
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.Get(399));
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.Get(-999));
        }
    }

    class Add : ProgramTests
    {
        [Test]
        public void TestIfAddAddsAValue()
        {
            _arraylist.Add(39);
            Assert.That(_arraylist.Get(0), Is.EqualTo(39));
        }

        [Test]
        public void TestIfAddAddsAValueToLastNode()
        {
            _arraylist.Add(32);
            _arraylist.Add(317);
            _arraylist.Add(14);
            Assert.That(_arraylist.Get(2), Is.EqualTo(14));
        }

        [Test]
        public void TestIfAddAddsAValueToLastNode2()
        {
            _arraylist.Add(32);
            _arraylist.Add(317);
            _arraylist.Add(14);
            Assert.That(_arraylist.Get(1), Is.EqualTo(317));
        }
    }

    class Remove : ProgramTests
    {
        [Test]
        public void TestRemoveOfOneNode()
        {
            _arraylist.Add(77);
            _arraylist.Remove(77);
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.Get(0));
        }

        [Test]
        public void TestRemoveOfOneNodeDownTheLine()
        {
            _arraylist.Add(48);
            _arraylist.Add(391);
            _arraylist.Add(33);
            _arraylist.Remove(33);
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.Get(2));
        }

        [Test]
        public void TestRemoveOfOneNodeInTheMiddle()
        {
            _arraylist.Add(48);
            _arraylist.Add(391);
            _arraylist.Add(33);
            _arraylist.Remove(391);
            Assert.That(_arraylist.Get(1), Is.Not.EqualTo(391));
        }

        [Test]
        public void TestExceptionArgumentException()
        {
            _arraylist.Add(48);
            _arraylist.Add(391);
            _arraylist.Add(33);
            Assert.Throws<ArgumentException>((() => _arraylist.Remove(3)));
        }
    }

    class FindIndex : ProgramTests
    {
        [Test]
        public void ValueNotFound()
        {
            _arraylist.Add(33);
            Assert.That(_arraylist.FindIndex(38), Is.EqualTo(-1));
        }

        [Test]
        public void ValueNotFound2()
        {
            _arraylist.Add(33);
            _arraylist.Add(798);
            _arraylist.Add(24);
            Assert.That(_arraylist.FindIndex(38), Is.EqualTo(-1));
        }

        [Test]
        public void ValueFound()
        {
            _arraylist.Add(33);
            Assert.That(_arraylist.FindIndex(33), Is.EqualTo(0));
        }
        
        [Test]
        public void ValueFound2()
        {
            _arraylist.Add(33);
            _arraylist.Add(39);
            Assert.That(_arraylist.FindIndex(39), Is.EqualTo(1));
        }
        [Test]
        public void ValueFound3()
        {
            _arraylist.Add(33);
            _arraylist.Add(39);
            _arraylist.Add(85);
            Assert.That(_arraylist.FindIndex(85), Is.EqualTo(2));
        }
    }

    class RemoveRange : ProgramTests
    {
        [Test]
        public void TestIfListIsNull()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.RemoveRange([1, 3]));
        }

        [Test]
        public void TestOneIndexIsOutOfRange()
        {
            _arraylist.Add(1);
            _arraylist.Add(2);
            _arraylist.Add(3);
            _arraylist.Add(4);
            
            Assert.Throws<IndexOutOfRangeException>(() => _arraylist.RemoveRange([2, 5]));
        }
        
        [Test]
        public void TestRemoveFirstThreeNumbers()
        {
            _arraylist.Add(1);
            _arraylist.Add(2);
            _arraylist.Add(3);
            _arraylist.Add(4);
            _arraylist.Add(5);
            _arraylist.Add(6);

            _arraylist.RemoveRange([1,3]);
            
            Assert.That(_arraylist.Get(0), Is.EqualTo(4));
        }
    }
}