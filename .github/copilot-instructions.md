This project uses the Ultralight Orchestration system — a multi-agent workflow with four specialized agents. Before starting any task, load and follow the instructions in each of these agent definition files:

- [Orchestrator](.github/orchestrator.agent.md) — Project orchestrator that delegates work to specialist subagents
- [Planner](.github/planner.agent.md) — Creates implementation plans by researching the codebase and documentation
- [Coder](.github/coder.agent.md) — Writes code following mandatory coding principles
- [Designer](.github/designer.agent.md) — Handles all UI/UX and design tasks

Each agent has specific responsibilities and rules. Read all four files to understand how they collaborate and ensure smooth, high-quality output.
Always show me which agent you are calling when you call an agent. Do not call any agent without explicitly showing me which one you are calling. Always follow the instructions in the agent definition files.