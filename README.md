# windows calculator in C# 

## 功能

- 输入
  - 可以输入整数、小数、复数
- 显示
  - textBox1显示当前计算内容
  - textBox2显示当前输入内容
- 清除
  - C清除所有内容
  - CE清除当前输入（textBox2）
  - Del输入退格
- 简单四则运算计算
- 键盘交互



## 思路

version1写的时候分析按键按下的不同情况，用了很多flag，思路混乱，有几个小细节总是有问题。

由于计算器一直在几个状态之间转换，所以version2用了状态机，思路清晰很多。

value saved:

- `numberOne`
- `numberTwo`
- `result`
- `operatorInput`

states:

- `numberInputting`
- `operatorInputted`
- `calculated`



## 过程中的学习

- 程序设计思路

- Visual Studio 操作、debugging

- C#

- 代码重用

- WPF

- 程序打包为setup

  > 直接拷贝的程序在缺少.NET的环境下无法运行。



## References

[How to Make a Calculator in C# Windows Form Application Part-1](https://www.youtube.com/watch?v=iJqB6UsM-hs&t=911s)

[How to Make a Calculator in C# Windows Form Application Part-2](https://www.youtube.com/watch?v=X67eC9jf2uE&t=1064s)

[First look at the Visual Studio Debugger](https://docs.microsoft.com/en-us/visualstudio/debugger/debugger-feature-tour?view=vs-2019)

[How to Create Setup.exe in Visual Studio 2019 | FoxLearn](https://www.youtube.com/watch?v=fehVTLNQorQ)

[Windows Presentation Foundation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/?view=netframeworkdesktop-4.8)

[How to programmatically click a button in WPF?](https://stackoverflow.com/questions/728432/how-to-programmatically-click-a-button-in-wpf)

[WPF Commanding - Keyboard Shortcuts](http://www.blackwasp.co.uk/WPFKeyBindings_3.aspx)

[To bubble or tunnel basic WPF events](https://www.codeproject.com/Articles/464926/To-bubble-or-tunnel-basic-WPF-events)