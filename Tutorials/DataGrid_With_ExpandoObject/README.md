# How To Bind To ExpandoObject collection
# 如何绑定到 ExpandoObject 集合

Avalonia Does not support binding to ExpandoObject collection directly. But you can add a customized BindingPlugin to support it.

Avalonia 不支持直接绑定到 ExpandoObject 集合。但是你可以添加一个自定义的 BindingPlugin 来支持它。

DataGrid 也不支持直接通过 ExpandoObject 集合自动生成列，所以需要一个 AttachedProperty 来支持它