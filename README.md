# CyanLib

Basically, all Unity extensions here are forked from [adammyhre](https://github.com/adammyhre)'s [Unity-Utils](https://github.com/adammyhre/Unity-Utils) repository with some minor changes.

## Features

- **Extension Methods:** Extend Unity and C# built-in types with additional functionalities.
- **Conversion Extension Methods:** Convert Vectors and Quaternions between System.Numerics and UnityEngine.
- **Hotkeys:** Lock Inspector, Close Tab, Compile Project and more.
- **Helpers:** Static helper methods such as NonAlloc WaitForSeconds.
- **Singletons:** Generic Singletons for various use cases.
- **Coordinates:** 2D and 3D representation of coordinates and directions. Can be used in grid systems.

## Dependencies

The package requires the Core RP Library due to the LoadVolumeProfile() extension.

## How to Use

- Simply download the library into your Unity project and access the utilities across your scripts
- Import it in Unity with package manager using this URL:

`https://github.com/CyanV98/CyanLib.git`

- Download last [release](https://github.com/CyanV98/CyanLib/releases) and import it in Unity project.

- With Git URL. Add the following line to the dependencies section of your project's manifest.json file.

```
"com.cyanv98.unityutils": "https://github.com/CyanV98/CyanLib.git"
```
