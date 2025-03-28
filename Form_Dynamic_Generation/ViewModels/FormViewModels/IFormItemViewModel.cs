namespace Form_Dynamic_Generation.ViewModels.FormViewModels;

public interface IFormItemViewModel
{
    public string? Label { get; set; }
    public bool IsRequired { get; set; }
}