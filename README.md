# EasyLocalization

A simple library that makes WPF Localization easier.

## Features

- An easy extension to use `{l:Localize Title1}`
- Handles bindable Key `{l:Localize Key={Binding TitleKey}}`
- Handles alternative keys when the Key is not provided or not found (ControlName_PropertyName, e.g. Button1_Content)
- Handles singular, zero and plural values `{l:Localize Key=Sentence1, CountSource={Binding Value}}`
  - The zero form is automatically used when the Count value is equal to 0
  - The plural form is automatically used when the Count value is greater than 0
- Ability to change the current culture without having to restart the application.

## Demo

![Demo GIF](https://i.imgur.com/fEO8Fjp.gif)

## How to use

### Things that you should know

- **EasyLocation** doesn't use resources.resx files (at least for now).
- **EasyLocation** works with cultures to identify languages (`CultureInfo` class)
- There are only 3 types of readers for now:
  - CharSeperatedFileReader: Each line is considered to have at least a key and a value seperated by a char (e.g. [en-US.txt](https://github.com/zHaytam/EasyLocalization/blob/master/EasyLocalization.Demo/Resources/en-US.txt))
  - JsonFileReader: A json file of a key-object format (e.g. [fr.json](https://github.com/zHaytam/EasyLocalization/blob/master/EasyLocalization.Demo/Resources/fr.json))
  - XmlFileReader: A xml file with an `<Entries>` root and `<Entry>` elements, each must have a key attribute (e.g. [es-ES.xml](https://github.com/zHaytam/EasyLocalization/blob/master/EasyLocalization.Demo/Resources/es-ES.xml))

### Adding cultures (languages)

On startup (for example in App.xaml.cs) you'll have to register the cultures you want your applications to have:
```
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);

    LocalizationManager.Instance.AddCulture(
        CultureInfo.GetCultureInfo("en-US"),
        new CharSeperatedFileReader("Resources/en-US.txt"),
        true);
    LocalizationManager.Instance.AddCulture(
        CultureInfo.GetCultureInfo("es-ES"),
        new XmlFileReader("Resources/es-ES.xml"));
    LocalizationManager.Instance.AddCulture(
        CultureInfo.GetCultureInfo("fr"),
        new JsonFileReader("Resources/fr.json"));
}
```

The `true` in the first `AddCulture` call tells the `LocalizationManager` to choose this language for now.

### Simple localization

    <TextBlock Margin="4" Text="{_:Localize Key1}" />
    <TextBlock Margin="4" Text="{_:Localize Key=Key1_1}" />

### Bindable Key

    <TextBlock Margin="4" Text="{localization:Localize KeySource={Binding Key} />

### Alterternative Key

    <TextBlock Margin="4" Name="LblTitle" Text="{localization:Localize}" />

Since the Key is not provided, the `LocalizationManager` will use the alternative key, in this case it's **LblTitle_Text**.

### Handling singular, zero and plural

    <TextBlock Margin="4"
               Text="{localization:Localize KeySource={Binding Key}, 
                                            CountSource={Binding Value}}" />

The LocalizationManager will adapt the Text property whenever the Key or Count change:
 - If the Count value is 0, the `ZeroValue` is chosen.
 - If the Count value is 1, the `Value` is chosen.
 - Otherwise the PluralValue is chosen `string.Format(PluralValue, Count)`

### Changing the culture (language)

    LocalizationManager.Instance.CurrentCulture = CultureInfo.GetCultureInfo("fr");

Whenever the CurrentCulture changes, the whole application is automatically updated without the need to restart it.

For a list of the available/added cultures:

    LocalizationManager.Instance.AvailableCultures

