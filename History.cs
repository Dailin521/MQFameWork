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
    