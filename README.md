## It's dangerous to go alone, take this! 🗡️

**GameWave** is a web app for managing your collection of physical and digital video games. It allows you to build a database of games and a universe of metadata about them.

### Features

- Games
- ROMs
- Platforms
- Developers
- Publishers
- Game modes
- Screenshots
- Videos
- High scores! 🕹️

### Built with

The backend was created with ASP.NET Core Web API and supports CRUD with optional pagination and searching. The frontend was created with Vue 3 and the [Vuetify 3 component framework](https://vuetifyjs.com/en/).

### Screenshot

![Screenshot](https://i.imgur.com/N35ja04.png)

### Running GameWave

1. Git clone
2. Set environment variables
3. Start backend: `dotnet run`
4. Start frontend: `npm run dev`

#### Environment variables

- ASPNETCORE_ENVIRONMENT: `Development` or `Production`
- SECRET_KEY: JWT signing key, a random passphrase.
- TOKEN_ISSUER: URL to the /api/{v1}/auth controller
- TOKEN_AUDIENCE: URL to the frontend