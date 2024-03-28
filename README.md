# Asset Name Packs

This mod allows you to add custom names to ingame assets in a simple text format.

Please note that this is a really early development version and I might add more features in the feature, e.g. full packs.

This mod is intended to be used with downloadable files of street name etc. that are widely available on the internet. Feel free to just write your own file in a theme of your choice and use it!

## Install Name Packs
This mod will create the directory required to use name packs on first launch. You can go ahead and create the directory yourself if you like. The directory location is different when manually installing, using thunderstore mod manager or r2modman.

To use a name pack, create a `packs/Default`-folder of this mod and add asset name files there. The files need to be named after the asset they are replacing. Please look at the example file in the Default folder. The file has to be a .txt file and include that language that is going to be used ingame.

Please note that the instructions differ for thunderstore mod manager and r2modman:

### r2modman
When using r2modman, you have to navigate to this folder to edit your files:
`C:\Users\[USERNAME]\AppData\Roaming\r2modmanPlus-local\CitiesSkylines2\profiles\[PROFILENAME]\BepInEx\plugins\[ASSETNAMEPACKS]\packs\Default`

`[ASSETNAMEPACKS]` is the name of this mod, which slightly differs, but mostly is something similar to `AssetNamePacks` or `AssetNamePacks-VERSION`.

### Thunderstore Mod Manager
When using Thunderstore Mod Manager, you have to navigate to this folder to edit your files:
`C:\Users[USERNAME]\AppData\Roaming\Thunderstore Mod Manager\DataFolder\CitiesSkylines2\profiles\[PROFILENAME]\BepInEx\plugins\[ASSETNAMEPACKS]\packs\Default`

`[ASSETNAMEPACKS]` is the name of this mod, which slightly differs, but mostly is something similar to `AssetNamePacks` or `AssetNamePacks-VERSION`.

## Dependencies

- BepInEx 5

## Installation

This mod can easily be installed using r2modman or Thunderstore Mod Manager. If you want to install it manually, follow these steps:

1. Make sure BepInEx 5 is installed
2. Download the file
3. Extract the `AssetNamePacks.zip` file into the `BepInEx\plugins` folder

## Supported Assets
Technically all assets that support numbering are supported already. I've yet to compile a full list. You can take a look at the localization files of Cities Skylines 2 to see more examples.

### Examples
#### Road Names
- `Assets.STREET_NAME`
- `Assets.HIGHWAY_NAME`
- `Assets.ALLEY_NAME`
- `Assets.DAM_NAME`
- `Assets.BRIGE_NAME`

#### Citizen Names
- `Assets.CITIZEN_NAME_MALE`
- `Assets.CITIZEN_SURNAME_MALE`
- `Assets.CITIZEN_NAME_FEMALE`
- `Assets.CITIZEN_SURNAME_FEMALE`
- `Assets.ANIMAL_NAME_DOG`

#### Misc
- `Assets.CITY_NAME`
- `Assets.DISTRICT_NAME`

## Compatibility
- This mod is not compatible with other mods replacing the localization files (I currently don't know any mods that do)

## Further Notes
- [Changelog](https://github.com/kosch104/CS2-AssetNamePacks/blob/main/CHANGELOG.md)



