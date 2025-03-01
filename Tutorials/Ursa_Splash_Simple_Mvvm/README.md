# How to create a splash screen with MVVM

# 如何使用MVVM创建一个启动画面

One of the common scenario of splash screen is to preload some resources before application really starts. Ursa SplashWindow makes it easy to show a splash screen with MVVM. You can implement `IDialogContext` interface to request closing splash screen, and create next `Window`.

启动画面的一个常见场景是在应用程序真正启动之前预加载一些资源。Ursa SplashWindow 使得使用 MVVM 显示一个启动画面变得容易。你可以实现 `IDialogContext` 接口来请求关闭启动画面，并创建下一个 `Window`。