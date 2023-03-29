1.快速开始： 
	点击开始->生成10个敌人->依次点击敌人至全部消失->显示游戏胜利界面
2.树结构 与 无架构项目的优缺点
	2.1 难维护，理不清引用关系
	2.2 难管理，团队协作会造成场景文件冲突
	2.3 难拓展，耦合高，牵一发动全身
4.对象之间的交互（低耦合） 和 模块化（高内聚）
  交互一般三种：
	*方法调用，例如：A调用B的Hello方法
	*委托或者回调，例如：界面监听子按钮的点击事件
	*消息或者事件，例如：服务器向客户端发送通知
  模块化一般三种：
	*单例，
	*IOC, 例如Extenject, UFrame的Container, StrangeIOC
	*分层，例如： MVC, 三层架构，领域驱动
	*其他，unity的Entity Component，门面模式等
  耦合是双向引用或循环引用，方法调用需要持有对象，这必然造成一次担心引用，
  所以方法调用达成一个共识，父节点可以调用子节点。
    *用委托来监听事件
  跨模块通信需要通过事件（Event）来通信
5.表现和数据要分离
	*用泛型+继承 提取Event工具类
	*子节点通知父节点可以用事件
	*表示和数据要分离（数据要在空间和时间上共存，数据类型有很多）
	*正确的代码要放在正确的位置（要符合正常逻辑）
6.交互逻辑和表现逻辑
	*交互逻辑：View->Model
	*表现逻辑：Model->View
7.表现逻辑游戏化-引入 BindableProperty（数据+数据变更事件）
	*表现逻辑用委托实现数据驱动
	*表现逻辑也可以用事件来驱动。
	//委托和事件用哪个？
	*如果是单个数值变化用委托更合适，如 金币，分数，等级等等
	*如果是颗粒度较大的更新用事件，比如从服务器拉去一个任务列表，然后任务列表数据（一堆各种类型数据）存到Model，此时Model的任务列表数据变更，向View发送事件合适
	*两个问题：一是Event工具类无法传参，二是每个数据都实现一遍，不聪明
	总结：
	*自底向上的逻辑  用委托和事件
	*自顶向下的逻辑  用方法调用
8.《点点点》使用 BindableProperty
9.交互逻辑优化-引入 Command
	*交互逻辑 会有很多 会让Controller变臃肿
	*Command模式可以让逻辑的调用和执行在空间（不同位置）和时间（不是像方法那样立刻调用）上分离
	*分担Controller的交互逻辑
	*struct 比 calss 有更好的内存管理效率
	*CQRS读写分离
