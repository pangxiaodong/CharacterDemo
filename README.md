# CharacterDemo

### Player

- CharacterData

  记录所有角色的Prefab

- Player

  挂在每个角色的GameObject下，负责访问SkinMeshRender等

- PlayerUtil

  离线工具，批量创建修改角色的Prefab上的Player脚本

- PlayerFactory

  负责创建角色，拥有缓存功能

### Camera

- CameraControl

  摄像机控制

### Dialog

- DlgCreateChar

  创建角色界面

