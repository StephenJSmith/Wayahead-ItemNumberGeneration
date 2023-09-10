using ItemNumberGenerationProject;
using FluentAssertions;

namespace ItemNumberGenerationTests;

public class ItemNumberGeneratorTests
{
  [Fact]
  public void SplitIncrement_WhenPassedValueAndLessThanCalculated_ThenSetToPassedValue()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);
    var expected = testSplitIncrement;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenPassedValueAndMOREThanCalculated_ThenSetToPassedValue()
  {
    // Arrange
    var testSplitIncrement = 20;
    var testMoreThanSplitIncrement = 21;
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = testMoreThanSplitIncrement, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);
    var expected = 30;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenAllSplitCountsEqual1_ThenCalculatedTo10()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 10;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountLessThan10_ThenCalculatedTo10()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 6, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 9, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 10;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountIs10_ThenCalculatedTo10()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 10, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 10;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountIs11_ThenCalculatedTo20()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 11, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 10, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 20;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountIs19_ThenCalculatedTo20()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 19, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 10, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 20;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountIs20_ThenCalculatedTo20()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 19, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 10, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 20;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void SplitIncrement_WhenMaxSplitsCountIs21_ThenCalculatedTo30()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 19, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 21, SplitsCount = 1 },
      };
    var sut = new ItemNumberGenerator(testItemInputs);
    var expected = 30;

    // Act
    var actual = sut.SplitIncrement;

    // Assert
    actual.Should().Be(expected);
  }

  [Fact]
  public void GetAllItemOutputs_NoSplitItems()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetAllItemOutputs_NoSplitItemsAndSplitIncrementIs10()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var testSplitIncrement = 10;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetAllItemOutputs_InitialStartValueAndNoSplitItems()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var testSplitIncrement = 20;
    var testInitialValue = 1000;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement, testInitialValue);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetAllItemOutputs_FirstItemWithSplitsAndItems()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 3, SplitsCount = 4 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 1 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetAllItemOutputs_MultiplItemsWithSplitsAndItems()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 2, SplitsCount = 3 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 3, SplitsCount = 4 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetAllItemOutputs_ItemsWithSplitsAndSingleItems()
  {
    // Arrange
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = "PB131", ItemsCount = 1, SplitsCount = 3 },
        new ItemInput {Id = "PB132", ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 1, SplitsCount = 4 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var actual = sut.GetAllItemOutputs();

    // Assert

  }

  [Fact]
  public void GetItemOutputs_MultiplItemsWithSplitsAndItems()
  {
    // Arrange
    var testSplitsId = "PB131";
    var testNoSplitsId = "PB133";
    var testItemInputs = new List<ItemInput>
      {
        new ItemInput {Id = testSplitsId, ItemsCount = 2, SplitsCount = 3 },
        new ItemInput {Id = testNoSplitsId, ItemsCount = 1, SplitsCount = 1 },
        new ItemInput {Id = "PB133", ItemsCount = 3, SplitsCount = 4 },
      };
    var testSplitIncrement = 20;
    var sut = new ItemNumberGenerator(testItemInputs, testSplitIncrement);

    // Act
    var splitsActual = sut.GetItemOutputs(testSplitsId);
    var noSplitsActual = sut.GetItemOutputs(testNoSplitsId);

    // Assert

  }
}
