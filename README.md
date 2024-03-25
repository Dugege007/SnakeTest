# SnakeTest
 贪吃蛇简单测试

控制：
- 用虚拟轴控制方向（Horizontal、Vertical）
- 每间隔一定时间移动一格
- 按下移动键直接移动一格
- 长按移动键加速移动

吃食物：
- 普通食物（黄色）加1分
- 大分食物（红色，1/10概率出现）加10分，速度+0.1

游戏结束：
- 撞墙或吃到自身，游戏结束
- 按空格键继续
- 按ESC键退出
- 保存历史最高分

核心逻辑：
- 头部在下一次移动之前，将位置信息传给尾部
- 头部移动后，将尾部移到头部上一次的位置

![微信截图_20240326002806](https://github.com/Dugege007/SnakeTest/assets/59428508/87f10af0-96cf-471e-a177-5e9c3f1c3242)
![微信截图_20240326002953](https://github.com/Dugege007/SnakeTest/assets/59428508/80454c01-083a-4460-ba56-8183ba7a4f20)
![微信截图_20240326002734](https://github.com/Dugege007/SnakeTest/assets/59428508/566b1258-6476-42af-b686-9fcd16a42a90)
![微信截图_20240326002756](https://github.com/Dugege007/SnakeTest/assets/59428508/b60f8c1f-d286-4446-9a3c-cb53af53dd06)
