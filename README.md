# 📸 Instagram Login Form — C# Windows Forms

![Platform](https://img.shields.io/badge/Platform-Windows-blue?style=flat-square&logo=windows)
![Language](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=csharp)
![Framework](https://img.shields.io/badge/Framework-.NET%20WinForms-512BD4?style=flat-square&logo=dotnet)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%202022-5C2D91?style=flat-square&logo=visualstudio)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

A pixel-perfect, professional **Instagram Login Form** built with **C# Windows Forms** in **Visual Studio 2022**. Features Instagram's iconic gradient button, Brush Script logo typography, clean card layout, placeholder animations, and full input validation — all implemented in pure C# with no external libraries.

---

## ✨ Features

- 🎨 **Instagram gradient login button** — authentic gold → red → pink → purple gradient
- ✍️ **Brush Script MT logo** — matches Instagram's wordmark style
- 📦 **White bordered card layout** — clean, minimal UI matching Instagram's web design
- 🔤 **Animated placeholder labels** — fade on focus for username and password fields
- 🔴 **Inline error validation** — red error messages for empty or incorrect fields
- 🔵 **"Log in with Facebook"** — secondary login option button
- 📱 **"Get the App" footer** — App Store & Google Play buttons
- 🖱️ **Hand cursor** on all interactive elements
- 🔒 **Password masking** with `●` characters
- ✅ **Demo credentials** for quick testing

---

## 🖼️ Preview

```
┌─────────────────────────────────────┐
│                                     │
│           Instagram                 │  ← Brush Script MT font
│                                     │
│  ┌─────────────────────────────┐    │
│  │ Phone number, username...   │    │  ← RoundedTextBox
│  └─────────────────────────────┘    │
│  ┌─────────────────────────────┐    │
│  │ Password                    │    │  ← PasswordBox (●●●●●)
│  └─────────────────────────────┘    │
│                                     │
│  ██████████████████████████████     │  ← Gradient Button
│           Log in                    │
│                                     │
│       Forgot password?              │
│  ───────────  OR  ───────────       │
│      🔵 Log in with Facebook        │
│                                     │
│  Don't have an account?  Sign up.   │
└─────────────────────────────────────┘
┌─────────────────────────────────────┐
│           Get the app.              │
│   [ App Store ]  [ Google Play ]    │
└─────────────────────────────────────┘
```

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community, Professional, or Enterprise)
- **.NET Desktop Development** workload installed
- **C# 8.0** or higher (see [Fixing C# Language Version](#%EF%B8%8F-fixing-c-language-version))

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/YOUR_USERNAME/InstagramLogin.git
   cd InstagramLogin
   ```

2. **Open in Visual Studio 2022**
   - Double-click `InstagramLogin.sln`
   - Or go to: File → Open → Project/Solution

3. **Build & Run**
   - Press `F5` or click the green ▶ **Start** button
   - The Instagram login form will launch centered on your screen

---

## 🔑 Demo Credentials

Use these to test a successful login:

| Field    | Value          |
|----------|----------------|
| Username | `demo`         |
| Password | `password123`  |

Any other combination will display an inline error message.

---

## 📁 Project Structure

```
InstagramLogin/
│
├── LoginForm.cs           # Main form — all UI built programmatically in code
├── Program.cs             # Entry point — launches LoginForm
├── InstagramLogin.csproj  # Project configuration file
├── InstagramLogin.sln     # Solution file
│
└── README.md              # You are here
```

### Key Classes

| Class | Description |
|---|---|
| `LoginForm` | Main window — builds all UI controls programmatically |
| `RoundedTextBox` | Custom `TextBox` with border painting and focus highlight |
| `GradientButton` | Custom `Button` with Instagram's iconic 4-color gradient |

---

## ⚙️ Fixing C# Language Version

If you see errors like *"Feature 'using declarations' is not available in C# 7.3"*:

1. Right-click the **project** in Solution Explorer → **Properties**
2. Go to **Build** tab → click **Advanced...**
3. Set **Language version** to `C# 8.0` or `latest`
4. Click **OK** and rebuild (`Ctrl+Shift+B`)

---

## 🛠️ How It Works

### Custom Gradient Button
The `GradientButton` class overrides `OnPaint` to draw Instagram's signature gradient using `LinearGradientBrush` with a `ColorBlend` of four stops:

```csharp
cb.Colors = new[]
{
    Color.FromArgb(255, 220, 90),   // Gold
    Color.FromArgb(250, 100, 60),   // Orange-Red
    Color.FromArgb(220, 50, 130),   // Pink
    Color.FromArgb(140, 30, 200)    // Purple
};
```

### Placeholder Labels
Since WinForms `TextBox` has no native placeholder support, overlapping transparent `Label` controls simulate the behaviour — hiding when the user types, reappearing when the field is cleared.

### Input Validation
The login button checks in order:
1. Username field is not empty
2. Password field is not empty
3. Credentials match the demo values (swap in real auth logic here)

---

## 🔧 Extending the Project

### Connect to a Real Database (SQL Server)
```csharp
// Add via NuGet: System.Data.SqlClient
string query = "SELECT * FROM Users WHERE Username=@u AND PasswordHash=@p";
using (var conn = new SqlConnection(connectionString))
using (var cmd = new SqlCommand(query, conn))
{
    cmd.Parameters.AddWithValue("@u", username);
    cmd.Parameters.AddWithValue("@p", hashedPassword);
    conn.Open();
    var result = cmd.ExecuteScalar();
}
```

### Hash Passwords Securely
```bash
# Install via NuGet Package Manager Console
Install-Package BCrypt.Net-Next
```
```csharp
// Hash on register
string hashed = BCrypt.Net.BCrypt.HashPassword(plainPassword);

// Verify on login
bool valid = BCrypt.Net.BCrypt.Verify(plainPassword, hashed);
```

### Add a Registration Form
```csharp
// In lnkSignup click handler
var registerForm = new RegisterForm();
registerForm.Show();
this.Hide();
```

---

## 🐛 Common Errors & Fixes

| Error | Cause | Fix |
|---|---|---|
| `CS8370: 'using declarations' not available in C# 7.3` | Language version too low | Set C# version to 8.0 in Project Properties → Build → Advanced |
| `CS0115: no suitable method found to override` | Code placed inside `Form1.cs`, conflicting with designer | Move all code to a new `LoginForm.cs` file |
| `CS1503: cannot convert 'Form1' to 'Form'` | `Program.cs` still references `Form1` | Change to `Application.Run(new LoginForm())` |
| Namespace mismatch errors | Project name contains `#`, which C# converts to `_` | Ensure all files use `LoginFormInC_UsingWindowsForms` as namespace |

---

## 📚 Technologies Used

| Technology | Purpose |
|---|---|
| C# 8.0 | Primary language |
| .NET Windows Forms | UI framework |
| Visual Studio 2022 | Development IDE |
| `System.Drawing` | Custom painting (`LinearGradientBrush`, `GraphicsPath`, `ColorBlend`) |
| Programmatic UI | No Designer `.resx` dependency — full code control |

---

## 📄 License

This project is licensed under the **MIT License** — free to use, modify, and distribute.

```
MIT License

Copyright (c) 2024 YOUR_NAME

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
```

---

## 🙌 Contributing

Contributions, issues and feature requests are welcome!

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/dark-mode`
3. Commit your changes: `git commit -m "Add dark mode toggle"`
4. Push to the branch: `git push origin feature/dark-mode`
5. Open a **Pull Request**

---

## 👤 Author

**Your Name**
- GitHub: [@YOUR_USERNAME](https://github.com/taimoor-ai)

---

> ⚠️ **Disclaimer:** This project is for **educational purposes only**. It is not affiliated with, endorsed by, or connected to Instagram or Meta Platforms, Inc. All Instagram-related branding, trademarks, and design elements are the property of their respective owners.
