# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/2.0.0-preview.2) - 2022-10-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-actions/milestone/5?closed=1)  
    

### Changed

- Update project ([#18](https://github.com/unity-game-framework/ugf-module-actions/issues/18))  
    - Update dependencies: `com.ugf.actions` to `3.0.0-preview.2` and `com.ugf.module.update` to `4.0.0-preview` versions.
    - Update package _Unity_ version to `2022.1`.
    - Update package _API Compatibility_ version to `.NET Standard 2.1`.
    - Add `Action` class with application reference.
    - Add `Action<TDescription>` and `Action<TDescription, TCommand>` abstract generic classes with description and application reference.
    - Add `ActionSystemDescribed<T>` abstract generic and related classes used to implement action system with description.
    - Add `ActionSystemList` and related classes as default implementation of system with actions described from system description.
    - Add `ActionSystemUpdate` and related classes as implementation of `ActionSystemList` class with registration at the specified update group.
    - Remove `ActionSystemUpdatable` class, replaced by `ActionSystemUpdate`.
    - Remove `ActionAsset<TAction>` abstract generic class.

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/2.0.0-preview.1) - 2021-06-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-actions/milestone/4?closed=1)  
    

### Changed

- Update update module dependency ([#17](https://github.com/unity-game-framework/ugf-module-actions/pull/17))  
    - Update dependencies: `com.ugf.module.update` to `3.0.0-preview.2` version.
    - Add `ActionModule.ProviderApplyQueueUpdateGroup` as default update group with action system and provider apply queue action.
    - Add `ActionSystemUpdatable` which implements `IUpdateHandler` and can be usable inside of update group.
    - Change `ActionModule` to contains only `IActionProvider` and `IContext` entities.
    - Change `ActionSystemDefaultAsset` to build `ActionSystem` without description.
    - Change `ActionUpdateGroupDefaultAsset` class to `ActionUpdateGroupAsset` which build `UpdateGroup` to update contained actions systems.
    - Remove `ActionSystemProvider` class, use `UpdateModule` instead to register action system in any update group.
    - Remove `ActionUpdateGroupProvider` class. use `UpdateModule` to register any update group.
    - Remove `ActionUpdateGroup` class. use regular `UpdateGroup` instead.
    - Remove `ActionSystemDescribed` and `ActionSystemDescription` classes.
    - Remove `ActionSystemAsset<TDescribed, TDescription>` class.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/2.0.0-preview) - 2021-03-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-actions/milestone/3?closed=1)  
    

### Changed

- Update action and application package ([#15](https://github.com/unity-game-framework/ugf-module-actions/pull/15))  
    - Update dependencies: `com.ugf.actions` to `3.0.0-preview` version and `com.ugf.module.update` to `3.0.0-preview` version.
    - Add `ActionSystemProvider` provider to manage action systems.
    - Add `ActionUpdateGroupProvider` provider to manage action update groups.
    - Change `IActionModule` and implementation to work using `IProvider` classes for _Groups_ and _Systems_, and remove all old related methods.
    - Change name of `ActionSystemAsset` class to `ActionSystemDefaultAsset`.
    - Change name of `ActionUpdateGroupAssetBase` class to `ActionUpdateGroupAsset`.
    - Change name of `ActionUpdateGroupAsset` class to `ActionUpdateGroupDefaultAsset`.
    - Change name of `ActionAssetBase` class to `ActionAsset`.
    - Remove `IActionContext` and replace by `IContext` from _UGF.RuntimeTools_ package.
    - Remove `IUpdateGroupDescribed` interface.
    - Remove deprecated code.
- Update package registry ([#14](https://github.com/unity-game-framework/ugf-module-actions/pull/14))  
    - Update package publish registry.

## [1.2.0](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/1.2.0) - 2021-01-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-actions/milestone/2?closed=1)  
    

### Changed

- Update dependencies ([#9](https://github.com/unity-game-framework/ugf-module-actions/pull/9))  
    - Update dependencies: `com.ugf.actions` to  `2.0.0` version and `com.ugf.module.update` to `2.1.0` version.
    - Deprecate `ActionModuleDescription` constructor with `registerType` argument, use properties initialization instead.

## [1.1.0](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/1.1.0) - 2021-01-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-actions/milestone/1?closed=1)  
    

### Added

- Add generic argument of TDescribed for ActionDescribedAsset  ([#6](https://github.com/unity-game-framework/ugf-module-actions/pull/6))  
    - Add `ActionDescribedAsset` with `TDescribed` and `TDescription` generic arguments.
    - Change `ActionDescribedAsset` with one generic argument to be deprecated.

### Changed

- Add lost interfaces for ActionDescribedAsset class ([#5](https://github.com/unity-game-framework/ugf-module-actions/pull/5))  
    - Add implementation of `IDescribedBuilder` and `IDescriptionBuilder` for `ActionDescribedAsset` class.

## [1.0.0](https://github.com/unity-game-framework/ugf-module-actions/releases/tag/1.0.0) - 2020-12-06  

### Release Notes

- No release notes.


