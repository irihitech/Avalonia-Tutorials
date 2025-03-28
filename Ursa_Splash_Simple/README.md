# How to add a simple Splash Screen to your Ursa project

# 如何为你的Ursa项目添加一个简单的启动画面

One of the common scenario of splash screen is to show a simple image or animation while the application is loading. Ursa SplashWindow makes it easy to show a simple splash screen. You can make application start from this SplashWindow, and ensure SplashWindow create a valid `Window` to show next by implementing `CreateNextWindow()` method. We provide a simple `CountDown` property to control the time of splash screen.

一个常见的启动画面场景是在应用程序加载时显示一个简单的图片或动画。Ursa SplashWindow 使得显示一个简单的启动画面变得容易。你可以让应用程序从这个 SplashWindow 开始启动，并通过实现 `CreateNextWindow()` 方法确保 SplashWindow 创建一个有效的 `Window` 来显示下一个窗口。我们提供了一个简单的 `CountDown` 属性来控制启动画面的时间。