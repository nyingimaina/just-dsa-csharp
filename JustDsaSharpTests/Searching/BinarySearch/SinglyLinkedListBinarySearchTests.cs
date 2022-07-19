using JustDsaSharp.DataStructures.LinkedLists;
using JustDsaSharp.Searching;
using JustDsaSharp.Searching.BinarySearch;

namespace JustDsaSharpTests.Searching.BinarySearch
{
    public class SinglyLinkedListBinarySearchTests
    {
        [Theory]
        [InlineData(5,4)]
        [InlineData(4,3)]        
        [InlineData(3,2)]        
        [InlineData(2,1)]
        [InlineData(1,0)]
        [InlineData(7, -1)]
        [InlineData(-1, -1)]
        public void HappyPathWorks(int valueToFind, int expectedResultIndex)
        {
            var singlyLinkedList = new SinglyLinkedList<int>(5)
                .Prepend(4)
                .Prepend(3)
                .Prepend(2)
                .Prepend(1);

            var searchResult = new SinglyLinkedListBinarySearch().Search
                <SinglyLinkedList<int>,int>(
                singlyLinkedList,
                comparer: (candidateValue) =>
                {
                    if (valueToFind < candidateValue)
                    {
                        return ComparisonResult.SearchValueIsLessThanCandidateValue;
                    }
                    else if (valueToFind > candidateValue)
                    {
                        return ComparisonResult.SearchValueIsGreaterThanCandidateValue;
                    }
                    else
                    {
                        return ComparisonResult.SearchValueEqualToCandidateValue;
                    }
                });
            if (searchResult != null && searchResult.Result != null)
            {
                Assert.False(searchResult.NotFound);
                Assert.Equal(valueToFind, searchResult.Result.Head.Value);
                Assert.Equal(expectedResultIndex, searchResult.ResultIndex);
            }
            else
            {
                Assert.True(valueToFind == -1 || valueToFind == 7);
            }
            
        }


        [Theory]
        [InlineData(5,4)]
        [InlineData(4,3)]        
        [InlineData(3,2)]        
        [InlineData(2,1)]
        [InlineData(1,0)]
        [InlineData(7, -1)]
        [InlineData(-1, -1)]
        public void SearchForNodeWorks(int valueToFind, int expectedResultIndex)
        {
            var singlyLinkedList = new SinglyLinkedList<int>(5)
                .Prepend(4)
                .Prepend(3)
                .Prepend(2)
                .Prepend(1);

            var searchResult = new SinglyLinkedListBinarySearch().SearchForNode(
                singlyLinkedList,
                comparer: (candidateValue) =>
                {
                    if (valueToFind < candidateValue)
                    {
                        return ComparisonResult.SearchValueIsLessThanCandidateValue;
                    }
                    else if (valueToFind > candidateValue)
                    {
                        return ComparisonResult.SearchValueIsGreaterThanCandidateValue;
                    }
                    else
                    {
                        return ComparisonResult.SearchValueEqualToCandidateValue;
                    }
                });
            if (searchResult != null && searchResult.Result != null)
            {
                Assert.False(searchResult.NotFound);
                Assert.Equal(valueToFind, searchResult.Result.Value);
                Assert.Equal(expectedResultIndex, searchResult.ResultIndex);
            }
            else
            {
                Assert.True(valueToFind == -1 || valueToFind == 7);
            }
            
        }

        [Theory]
        [InlineData(5,4)]
        [InlineData(4,3)]        
        [InlineData(3,2)]        
        [InlineData(2,1)]
        [InlineData(1,0)]
        [InlineData(7, -1)]
        [InlineData(-1, -1)]
        public void SearchForValueWorks(int valueToFind, int expectedResultIndex)
        {
            var singlyLinkedList = new SinglyLinkedList<int>(5)
                .Prepend(4)
                .Prepend(3)
                .Prepend(2)
                .Prepend(1);

            var searchResult = new SinglyLinkedListBinarySearch().SearchForValue(
                singlyLinkedList,
                comparer: (candidateValue) =>
                {
                    if (valueToFind < candidateValue)
                    {
                        return ComparisonResult.SearchValueIsLessThanCandidateValue;
                    }
                    else if (valueToFind > candidateValue)
                    {
                        return ComparisonResult.SearchValueIsGreaterThanCandidateValue;
                    }
                    else
                    {
                        return ComparisonResult.SearchValueEqualToCandidateValue;
                    }
                });
            if (searchResult != null)
            {
                Assert.False(searchResult.NotFound);
                Assert.Equal(valueToFind, searchResult.Result);
                Assert.Equal(expectedResultIndex, searchResult.ResultIndex);
            }
            else
            {
                Assert.True(valueToFind == -1 || valueToFind == 7);
            }
            
        }

        [Fact]
        public void NullInputReturnsNull()
        {
            Assert.Null(
                new SinglyLinkedListBinarySearch()
                    .Search<SinglyLinkedList<int>, int>(
                        null,(_) => ComparisonResult.SearchValueIsLessThanCandidateValue));
        }

        [Fact]
        public void InvalidComparisonResultThrowsException()
        {
            Assert.Throws<InvalidComparisonResultException>(() =>
                new SinglyLinkedListBinarySearch()
                    .Search<SinglyLinkedList<int>, int>(
                        new SinglyLinkedList<int>(32),(_) => (ComparisonResult)9));
        }
    }
}