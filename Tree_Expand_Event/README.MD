# How to subscribe to TreeView node Expand/Collapse event
# 如何订阅 TreeView 节点展开/折叠事件

Avalonia's `TreeView` doesn't have a Expanded/Collapsed event, but You can subscribe to `TreeViewItem.Expanded` or `TreeViewItem.Collapsed` event directly in TreeView level. You can get the node information from event `Source`.

Avalonia 的 `TreeView` 没有 Expanded/Collapsed 事件，但是你可以直接在 TreeView 级别订阅 `TreeViewItem.Expanded` 或 `TreeViewItem.Collapsed` 事件。你可以从事件 `Source` 获取节点信息。