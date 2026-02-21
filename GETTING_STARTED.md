# Getting Started

This project uses **VS Code** with **GitHub Copilot** and a multi-agent orchestration system to build the application from a single prompt.

## How It Works

The `.github/` folder contains instruction files that guide Copilot's behavior:

- **`copilot-instructions.md`** — Loaded automatically by VS Code. Tells Copilot to follow the Ultralight Orchestration system with four specialized agents.
- **`orchestrator.agent.md`** — Breaks down tasks and delegates to specialist agents.
- **`planner.agent.md`** — Researches the codebase and creates implementation plans.
- **`coder.agent.md`** — Writes code following mandatory coding principles.
- **`designer.agent.md`** — Handles UI/UX and design decisions.
- **`prompts/qr-code-generator.md`** — The task description for building this app.

VS Code reads these files automatically and uses them to shape how Copilot responds.

## Get Started

1. Open this project in **VS Code**
2. Make sure **GitHub Copilot** is installed and enabled
3. Open **Copilot Chat** in **Agent mode**
4. Paste this prompt:

   ```
   you would complete the task described in @.github/prompts/qr-code-generator.md. Always read the @.github/copilot-instructions.md
   ```

5. Copilot will read the agent definitions, plan the work, and build the entire application — scaffolding the .NET project, generating QR code services, pages, and styling.

> **Tip:** You can also start with **Plan mode** first to review the implementation strategy before Copilot writes any code.

## Compare Your Solution

Once you're done, you can compare your result with a reference implementation on the `jadeoti/completed` branch (built with .NET 10):

```bash
git diff main jadeoti/completed
```

Or check it out directly:

```bash
git checkout jadeoti/completed
```
