## FxBlox

### What is the work being proposed?
We have started work on a mobile app interface for Smartnode setup and operation. This app has a clear mission: simplifying the complexities of becoming a Rocket Pool node owner, making it approachable for a broad user base with little to no technical background. The app is cross-platform, designed with utmost care, ensuring it is easy to navigate, intuitive, and user-friendly.

The current scope of the project is local staking hardware nodes. The app guides users through a step-by-step wizard, assisting them in connecting their device to their home network and establishing a remote connection via Libp2p for remote accessibility. It then deploys an opinionated configuration for their Smartnode, requiring minimal user input. After the quick-setup step, users enter a dashboard to monitor their node's status and customize settings to their liking. While the current scope of the work doesn't encompass setting up on a laptop or virtual machine, the app is [architected in a way](https://github.com/functionland/fx-blox/blob/main/docs/fx-stack-overview.md) that allows for the addition of these capabilities in future development phases. Although our initial focus is on Android, the framework we've chosen, MAUI Blazor, allows for expansion to iOS, Windows, and Mac.

The inspiration for initiating this project stemmed from [conversations](https://discord.com/channels/405159462932971535/405164275036848128/1144912479936323614) within the [#hardware](https://discord.com/channels/405159462932971535/405164275036848128) channel on Discord. The idea of a mobile app interface was met with enthusiasm. Community members recognized that such an interface could significantly lower entry barriers, making it easier to introduce Rocket Pool solo staking to a wider audience, especially normies. The project was given the green light in September after a meeting with @jcrtp, @darcius and @langers, with @jcrtp confirming that the required APIs can be integrated into the Smartnode code. Development commenced and the project has already amassed over 200 commits. The progress achieved, as shown in the GIF below, was demoed to @darcius and @langers, they recommended that we proceed with a grant proposal.

[Android APK installer of the demo](https://drive.google.com/file/d/1IKGYJNC-Rj19_Axm21TClfsI6BGuyE-s/view?usp=sharing)

[Repo on GitHub](https://github.com/functionland/fx-blox)

![Demo](https://github.com/functionland/fx-blox/assets/1758649/1f64f4ba-fe94-4a3f-9171-4d526a47b447)



### Is there any related work this builds off of?
 - We should search for it
 - Describe similar UI in Fula

### Will the results of this project be entirely open source? If not, which parts will not be, why, and under what license will they be published?
 - Yes, everything is [MIT](https://opensource.org/licenses/MIT) licensed.

## Benefits - enter N/A where appropriate
### How does this help people looking to stake ETH for rETH?
 - This is a bridge for mass adoption

### How does this help rETH holders?
 - Make the network more decentralized
 - Help move nodes from the cloud to the edge

### How does this help people looking to run a Rocket Pool node for the first time?
 - We are making this as easy as a pie!

### How does this help people already running a Rocket Pool node?
 - Not in the scope of this grant, but in the future we can add a feature to have this UI for already running nodes.

### How does this help the Rocket Pool community?
 - Can tell their non-geek friends about it

### How does this help RPL holders?
 - Provides the means to massively decentralize the infrastructure and add a huge user base of node operators

### What other non-RPL protocols, DAOs, projects, or individuals, would stand to benefit from this grant?
 - Functionland
 - SSV Network
 
### Will the resulting project be open source?
 - YES, everything is open source.

## Team

### Who is doing the work?
 - [Mehran](https://github.com/mehrandvd): Software Architect, PM
 - [Keyvan](https://github.com/keyvan-m-sadeghi)
 - [Ehsan](https://github.com/ehsan6sha)
 - [Afshin](https://github.com/afshinalizadeh): Senior Develoer
 - [Maryam](https://github.com/Marirood): UI/UX Developer
 - [Hootan](https://github.com/hootanht): UI Developer


### What is the background of the person(s) doing the work? What experience do they have with such projects in the past?

Functionland started as a participant of 2021 Filecoin Hackathon, in which our backend project (named “Box” at the time) [won the first place](https://filecoin.io/blog/posts/249k-for-17-projects-from-dorahacks-filecoin-grant-hackathon/), and our mobile photo gallery app (named “Photos” at the time, now renamed to “FxFotos”) won the third place.

[This blog post](https://dev.to/fx/google-photos-open-source-alternative-with-react-native-80c) announcing these projects, we amassed 500+ stars on GiHub on the first week.

We also ran a [crowdfunding campaign](https://www.indiegogo.com/projects/box-first-free-forever-cloud-storage-alternative#/) for the hardware, where we raised over half a million dollars for the devices (shipping starts April).

Functionland was incorporated in Canada after the Hackathon and [we closed a $1.1M seed](https://www.newswire.ca/news-releases/functionland-raises-1-1m-in-seed-funding-830473543.html) round in January 2022.

Essentially, we are a team of 20 developers, software architects, UI/UX designers, testers and… with an endless thirst to bring the true essence of blockchain into people’s life.
I’m Keyvan, and I’m representing this great team. If you want to know more about our team, there is more in this link: [Functionland’s Team of Ninjas](https://mehrandvd.com/2022/12/18/building-a-ninja-team-for-fxland/)

 #### Our Core Team
   - [Mehran](https://github.com/mehrandvd)
     - 20+ years of experience in software development
     - .NET guru
     - Managed lots of projects with team size of 20+
     - 5+ years of experience on Azure
   - [Keyvan](https://github.com/keyvan-m-sadeghi)
     - _[Background]_
   - [Ehsan](https://github.com/ehsan6sha)
     - _[Background]_
   - [Afshin](https://github.com/afshinalizadeh)
     - 20+ years of experience in software development
     - Worked with a variety of technologies: C#, Java, JavaScript, TypeScript, React, Angular, Blazor, Maui, ...
     - Experienced in development for almost every platform: Android, iOS, Windows, macOS, Linux
     - A principal engineer in developing FxFiles
     - A principal engineer in developing TonRich
     - There is literally nothing defined as difficult for Afshin, he will do it!
   - [Maryam](https://github.com/Marirood)
     - 10+ years of experience in UI/UX
     - Master of CSS and styles
     - Experienced in Blazor
     - The main UI/UX developer of [TonRich](https://github.com/tonradar/tonrich)
   - [Hootan](https://github.com/hootanht)
     - Experienced in Blazor
     - Experienced in CSS and styles
     - Experienced in designing complicated UIs
 
#### Our Previous Projects
   - FxFiles
   - FxFotos
   - [TonRich](https://github.com/tonradar/tonrich)
   - Ton.Fragment Nuget Package: A .NET SDK to work with [fragment.com](https://fragment.com) auctions on TON

### What is the breakdown of the proposed work, in terms of milestones and/or deadlines?
 - Milestone 0: Initial App (Already Done)
 - Milestone 1: UI
 - Milestone 2: Backend and P2P logic
 - Milestone 3: Connecting to RocketPool SDK

### How is the work being tested? Is testing included in the schedule?
 To ensure the quality of the app, we have various methods
 - **Unit Tests**: For critical sections of the logic
 - **Integration Tests**: Automated tests to test the most frequent scenarios
 - **Android Specific Tests**: Some tests that are specialized to test Android-specific code
 - **UAT Tests**: The whole application will be tested by our QA team before each release to ensure everything works fine from an end-user perspective

### How will the work be maintained after delivery?
 - This is not only a RocketPool-specific application. Instead, it is a key application in Functionaland's ecosystem and our business is tightly involved with success of this application.
 - The feature expansion will be supported for follow-up grants and bounties.

## Payment and Verification

### What is the acceptance criteria?
 - The app will be available on PlayStore for download
 - The source code will be available on GitHub
 - The designs will be available on Figma

### What is the proposed payment schedule for the grant? How much USD $ and over what period of time is the applicant requesting?
 - Totally: 50,000 USD stablecoin
 - Milestone 1 (UI): 50% (**$25,000 at the end of 4th week**)
 - Milestone 2 (Backend and P2P logic): 30% (**$15,000 at the end of 8th week**)
 - Milestone 3 (Connecting to RocketPool SDK): 20% (**$10,000 at the end of 12th week**)

### How will the GMC verify that the work delivered matches the proposed cadence?
 - The app will be available on PlayStore for download
 - The source code will be available on GitHub
 - The designs will be available on Figma

### What alternatives or options have been considered in order to save costs for the proposed project?
 - We are using cross-platform technologies to reduce the costs of development for different platforms
 - We have a small efficient fully remote team

## Conflict of Interest
  
### Does the person or persons proposing the grant have any conflicts of interest to disclose? (Please disclose here if you are a member of the GMC or if any member of the GMC would benefit directly financially from the grant).
 - None
   
### Will the recipient of the grant, or any protocol or project in which the recipient has a vested interest (other than Rocket Pool), benefit financially if the grant is successful?```
 - None
