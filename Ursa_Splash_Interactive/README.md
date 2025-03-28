# How to add an interactive splash screen to your Ursa project
# 如何为你的Ursa项目添加一个交互式启动画面

One of the common scenario of splash screen is login screen. Ursa SplashWindow makes it easy to redirect to next window based on login result. When SplashScreen ViewModel implements `IDialogContext` interface, you can pass a dialog result to SplashWindow, and create next `Window` based on the dialog result. If next window is null, the application will be closed.

一个常见的启动画面场景是登录画面。Ursa SplashWindow 使得根据登录结果重定向到下一个窗口变得容易。当 SplashScreen ViewModel 实现了 `IDialogContext` 接口，你可以将一个对话框结果传递给 SplashWindow，并根据对话框结果创建下一个 `Window`。如果下一个窗口是 null，应用程序将被关闭。