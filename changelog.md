# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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


