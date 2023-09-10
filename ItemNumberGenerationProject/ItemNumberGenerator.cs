namespace ItemNumberGenerationProject;

public class ItemNumberGenerator
{
  private readonly IList<ItemInput> _itemInputs;
  private readonly int _splitIncrement;
  private readonly int _initialVaLue;
  private readonly IList<ItemOutput> _itemOutputs;

  private int _nextItemBaseValue;

  public int SplitIncrement => _splitIncrement;

  public ItemNumberGenerator(
    IList<ItemInput> itemInputs,
    int splitIncrement = 0,
    int initialValue = 0,
    bool isDynamicSplitIncrement = false)
  {
    _itemInputs = itemInputs;
    _initialVaLue = initialValue;
    _splitIncrement = Math.Max(splitIncrement, GetSplitIncrementForMaxItemsCount());

    _itemOutputs = new List<ItemOutput>();
    _nextItemBaseValue = _initialVaLue - _splitIncrement;

    if (isDynamicSplitIncrement)
    {
      GenerateAllDynamicItemNumbers();
    }
    else
    {
      GenerateAllItemNumbers();
    }
  }

  public IList<ItemOutput> GetAllItemOutputs()
  {
    return _itemOutputs;
  }

  public IList<ItemOutput> GetItemOutputs(string id)
  {
    return _itemOutputs.Where(i => i.Id == id).ToList();
  }

  private int GetSplitIncrementForMaxItemsCount()
  {
    var maxItemsCount = _itemInputs.Max(i => i.ItemsCount);
    return GetCalculatedSplitIncrement(maxItemsCount);
  }

  private static int GetCalculatedSplitIncrement(int input)
  {
    var addend = input % 10 == 0
      ? 0
      : 1;
    var result = ((input / 10) + addend) * 10;

    return result;
  }

  #region Constant SplitIncrement

  private void GenerateAllItemNumbers()
  {
    foreach (var itemInput in _itemInputs)
    {
      GenerateItemItemNumbers(itemInput);
    }
  }

  private void GenerateItemItemNumbers(ItemInput itemInput)
  {
    for (int splitIndex = 1; splitIndex <= itemInput.SplitsCount; splitIndex++)
    {
      for (int itemIndex = 1; itemIndex <= itemInput.ItemsCount; itemIndex++)
      {
        var outputIncrement = (splitIndex * _splitIncrement) + (itemIndex - 1);
        var itemNumber = _nextItemBaseValue + outputIncrement;

        AddItemOutput(itemInput, splitIndex, itemIndex, itemNumber);
      }
    }

    _nextItemBaseValue += itemInput.SplitsCount * _splitIncrement;
  }

  #endregion

  #region Dynamic SplitIncrement

  private void GenerateAllDynamicItemNumbers()
  {
    foreach (var itemInput in _itemInputs)
    {
      GenerateDynamicItemItemNumbers(itemInput);
    }
  }

  private void GenerateDynamicItemItemNumbers(ItemInput itemInput)
  {
    var splitIncrement = GetCalculatedSplitIncrement(itemInput.ItemsCount);

    for (int splitIndex = 1; splitIndex <= itemInput.SplitsCount; splitIndex++)
    {
      for (int itemIndex = 1; itemIndex <= itemInput.ItemsCount; itemIndex++)
      {
        var outputIncrement = (splitIndex * splitIncrement) + (itemIndex - 1);
        var itemNumber = _nextItemBaseValue + outputIncrement;

        AddItemOutput(itemInput, splitIndex, itemIndex, itemNumber);
      }
    }

    _nextItemBaseValue += itemInput.SplitsCount * splitIncrement;
  }

  #endregion

  private void AddItemOutput(ItemInput itemInput,
    int splitIndex, int itemIndex, int itemNumber)
  {
    var itemOutput = new ItemOutput
    {
      Id = itemInput.Id,
      SplitsCount = itemInput.SplitsCount,
      ItemsCount = itemInput.ItemsCount,
      ItemIndex = itemIndex,
      SplitIndex = splitIndex,
      ItemNumber = itemNumber
    };

    _itemOutputs.Add(itemOutput);
  }
}

