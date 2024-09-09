# MdiWpf

MdiWpf is a .NET library that contains the Material Design Icons.

The icons are embedded in the library in svg format and their data are parsed with the `IconsManager` class.

The markup extensions `IconSource` and `IconGeometry` make the usage in XAML as easy as possible.

It also contains the `VectorIcon` control that helps to display icons
in an Image with DataBinding for Geometry and Brush.

[Icons license](https://github.com/Templarian/MaterialDesign/blob/master/LICENSE)

[Material Design Icons GitHub repo](https://github.com/Templarian/MaterialDesign)

[Pictogrammers website](https://pictogrammers.com/library/mdi/)

## Examples

Import namespace in XAML :

```xaml
xmlns:mdi="clr-namespace:MdiWpf;assembly=MdiWpf"
xmlns:controls="clr-namespace:MdiWpf.Controls;assembly=MdiWpf"
```

Example of `IconSource` markup extension with an image :

```xaml
<Image Source="{mdi:IconSource IconName='barcode-scan', Brush=Coral}" />
```

Example of `IconGeometry` markup extension with a `VectorIcon` :

```xaml
<controls:VectorIcon Geometry="{mdi:IconGeometry IconName='server-security'}"
                     Brush="Magenta" />
```

Example with binding : 

```xaml
<controls:VectorIcon Geometry="{Binding Geometry}"
                     Brush="{Binding Brush}" />
```

```csharp
Brush = Brushes.Blue;
Geometry = IconsManager.GetIconGeometry("source-repository");
```

2024 - Josué Clément