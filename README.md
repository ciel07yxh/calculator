# windows calculator in C# 

## 功能

- 输入
  - 可以输入整数、小数、复数
- 显示
  - textBox1显示当前计算内容
  - textBox2显示当前输入内容

- 简单四则运算计算



## 思路

version1 写的时候分析按键按下的不同情况，用了很多flag，思路混乱，有几个小细节总是有问题。

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

- 程序设计思路（设计可能比实现更重要）
- Visual Studio debugging
- C# 
- 代码重用
- WPF
- 程序打包