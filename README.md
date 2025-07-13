# Scene Reference

## Setup

### Requirements

* Unity 2022.3 or later

### Installation

#### Install via UPM (using git URL)

1. Open `Package Manager` from `Window > Package Manager`.
2. Click `'+'` button and `Install package from git URL`.
3. Enter following URL:

```
https://github.com/n11ckz/scene-reference.git?path=Assets/Plugins/SceneReference
```

#### Install manually (using .unitypackage)

1. Open [Releases](https://github.com/n11ckz/scene-reference/releases) page and download `.unitypackage` file.
2. Drag it to `Unity` and click `Import` button.

## Usage

Create `SceneReference` field in your class and use `Name` or `BuildIndex` properties for loading the scene. 

```c#
public class Sample : MonoBehaviour
{
    [SerializeField] private SceneReference _sceneReference;
    
    public void BackToMenu()
    {
        // You can validate that scene was added to build before loading
        if (_sceneReference.IsAddedInBuild == false)
            return;
        	
        SceneManager.LoadScene(_sceneReference.BuildIndex);
    }
}
```

Don't forget to specify the `Scene Asset` in inspector. Field will automatically set necessary values! You can view them by expanding `Scene Info` foldout.

<div align="center">
  <img src="https://n11ckz.s-ul.eu/ikFDkO0H">
</div>

You can also take a look at more interesting [sample](https://github.com/n11ckz/scene-reference/tree/main/Assets/_Samples) where buttons that load levels in game will be created at runtime using config file.

## License

- Unlicense
