namespace RealSolutionFolders.Converters;

using System.Windows;
using System.Windows.Data;

using LambdaConverters;

public static class Converter
{
    public static readonly IValueConverter VisibleWhenTrue =
        ValueConverter.Create<bool, Visibility>(e => e.Value ? Visibility.Visible : Visibility.Collapsed);

    public static readonly IValueConverter InvertBoolean =
        ValueConverter.Create<bool, bool>(e => !e.Value);
}
