<!DOCTYPE html>
<html lang="zh-Hant">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
  <title>自我介紹</title>
  <style>
    body {
      margin: 0;
      padding: 0;
      font-family: 'Segoe UI', sans-serif;
      background: linear-gradient(120deg, #0f0c29, #302b63, #24243e);
      background-size: 600% 600%;
      animation: gradientBG 15s ease infinite;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
      color: white;
    }

    @keyframes gradientBG {
      0% { background-position: 0% 50%; }
      50% { background-position: 100% 50%; }
      100% { background-position: 0% 50%; }
    }

    .card {
      background: rgba(255, 255, 255, 0.1);
      border: 1px solid rgba(255, 255, 255, 0.2);
      backdrop-filter: blur(10px);
      border-radius: 20px;
      padding: 40px;
      width: 300px;
      text-align: center;
      box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
      animation: fadeInUp 1s ease forwards;
      transform: translateY(30px);
      transition: transform 0.3s ease;
    }

    .card:hover {
      transform: translateY(10px) rotateY(5deg) rotateX(5deg);
    }

    @keyframes fadeInUp {
      to {
        opacity: 1;
        transform: translateY(0);
      }
      from {
        opacity: 0;
        transform: translateY(30px);
      }
    }

    h1 {
      font-size: 2em;
      margin-bottom: 20px;
      color: #ffffff;
    }

    .info {
      text-align: left;
      font-size: 1.1em;
      line-height: 1.8;
    }

    .info span {
      font-weight: bold;
      color: #ffda79;
    }
  </style>
</head>
<body>
  <div class="card">
    <h1>自我介紹</h1>
    <div class="info">
      <p><span>姓名：</span>王小明</p>
      <p><span>生日：</span>2005/05/25</p>
      <p><span>性別：</span>男</p>
      <p><span>興趣：</span>打電動、畫圖、寫程式</p>
    </div>
  </div>
</body>
</html>
# Just a small game
 
