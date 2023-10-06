## FxBlox

> NOTE: removed links from this post to comply with the 2 links allowed for new users. Please read from [here](https://github.com/functionland/fx-blox/blob/main/docs/grants/rocketpool-round-5.md) for all links to work. In this post links from the original text are just _Italic_, meaning they were links in the original text.

### What is the work being proposed?
We have started work on a mobile app interface for Smartnode setup and operation. This app has a clear mission: simplifying the complexities of becoming a Rocket Pool node owner, making it approachable for a broad user base with little to no technical background. The app is cross-platform, designed with utmost care, ensuring it is easy to navigate, intuitive, and user-friendly.

The current scope of the project is local hardware nodes. The app guides users through a step-by-step wizard, assisting them in connecting their device to their home network and establishing a remote connection via Libp2p for remote accessibility. It then deploys an opinionated configuration for their Smartnode, requiring minimal user input. After the quick-setup step, users enter a dashboard to monitor their node's status and customize settings to their liking. While the current scope of the work doesn't encompass setting up on a laptop or virtual machine, the app is _architected in a way_ that allows for the addition of these capabilities in future development phases. Although our initial focus is on Android, the framework we've chosen, MAUI Blazor, allows for expansion to iOS, Windows, and Mac.

The inspiration for initiating this project stemmed from _conversations_ within the _#hardware_ channel on Discord. The idea of a mobile app interface was met with enthusiasm. Community members recognized that such an interface could significantly lower entry barriers, making it easier to introduce Rocket Pool solo staking to a wider audience, especially normies. The project was given the green light in September after a meeting with _Joe_, _Dave_ and _Langers_, with @jcrtp confirming that the required APIs can be integrated into the Smartnode code. Development commenced and the project has already amassed over 200 commits. The progress achieved, as shown in the GIF below, was demoed to _Dave_ and @langers, they recommended that we proceed with a grant application.

![Demo](https://github.com/functionland/fx-blox/assets/1758649/1f64f4ba-fe94-4a3f-9171-4d526a47b447)

### Is there any related work this builds off of?

This project builds upon the groundwork laid by Functionland, as detailed in the following sections.

### Will the results of this project be entirely open source? If not, which parts will not be, why, and under what license will they be published?
 - Yes, everything is MIT licensed.

## Benefits - enter N/A where appropriate
### How does this help people looking to stake ETH for rETH?
This initiative holds the potential to serve as a bridge for mass adoption, facilitating the process for individuals looking to stake ETH. It opens up the opportunity for a broader audience, including those with little technical knowledge, to participate in the network. This approach also contributes to decentralizing the network further by catering directly to home node operators, reducing reliance on cloud-based infrastructure, and promoting a more distributed ecosystem. It encourages the transition of nodes from the cloud to the edge, strengthening the overall robustness and resilience of the network.

### How does this help rETH holders?

In this phase, indirectly, but with the possibility of concrete future plans emerging from the community involving the mobile app.

### How does this help people looking to run a Rocket Pool node for the first time?

This project aids first-time Rocket Pool node operators by offering a user-friendly mobile app interface that simplifies node setup. It provides step-by-step guidance for connecting hardware nodes, establishing remote accessibility, and configuring the node with minimal user input. This accessibility and ease of use remove barriers for newcomers, enabling them to participate confidently in the Rocket Pool network.

### How does this help people already running a Rocket Pool node?

Not in the scope of this grant, but future phases can add a feature to have this UI for already running nodes.

### How does this help the Rocket Pool community?

This initiative primarily benefits the Rocket Pool community by enabling its members to easily onboard their non-technical friends and acquaintances into the world of Rocket Pool solo staking. With the mobile app as the entry point instead of CLI, Rocket Pool will be accessible to a broader audience, thereby expanding the community and increasing the platform's reach.

### How does this help RPL holders?

This project can potentially benefit RPL holders in two significant ways. Firstly, if the project succeeds in its mission and attracts a large user base, it could strengthen the value of RPL through increased demand and usage within the Rocket Pool ecosystem. Secondly, by providing the means to massively decentralize the infrastructure, it aligns with the broader goals of blockchain networks, enhancing the security and resilience of the ecosystem, which can positively impact RPL holders by bolstering the overall health and stability of the network.

### What other non-RPL protocols, DAOs, projects, or individuals, would stand to benefit from this grant?

Our team, _Functionland_, has a broader goal centered around introducing a new product category named "Smart Server." Functionland has a substantial community with over 1,000 members _on Telegram_. We demonstrated market fit through a successful _crowdfunding campaign_ that raised over half a million USD, with all devices shipped this year. Given this context, the grant's benefits extend beyond the Rocket Pool ecosystem to potentially include anyone interested in the Smart Server concept that Functionland is striving to introduce. The project's success could have ripple effects, positively impacting a wide range of stakeholders interested in this emerging product category.

There is also interest from  _SSV Network_ in exploring integration possibilities. The ultimate aim there is leveraging their Distributed Validator Technology in conjunction with the pool mechanism in Rocket Pool. This collaboration could enable users to form pools where their devices serve as backups for each other, assuring no downtime. Additionally, it would open up opportunities for users to stake with significantly smaller amounts of ETH, making participation in staking more inclusive and accessible. This potential partnership could have far-reaching implications for the broader blockchain and staking communities.
 
### Will the resulting project be open source?

 - YES, _it already is._

## Team

### Who is doing the work?

 - _Mehran_, Software Architect, PM
 - _Keyvan_, Software Architect, CoPM
 - _Ehsan_, UX Architect, CoPM
 - _Afshin_, Senior Develoer
 - _Maryam_, UI/UX Developer
 - _Hootan_, UI Developer

### What is the background of the person(s) doing the work? What experience do they have with such projects in the past?

Functionland's journey began as a participant in the 2021 Filecoin Hackathon, where our backend project, initially named "Box," secured the _first-place position_, and our mobile photo gallery app, formerly known as "Photos" and now renamed "FxFotos," claimed third place. The _article introducing FxFotos_ led to us amassing _over 500 stars on GitHub_ within the first week.

Following the Hackathon, Functionland was formally incorporated in Canada, and we successfully _closed a $1.1 million seed round_ in January 2022. Our team consists of 20 dedicated professionals, including developers, software architects, UI/UX designers, testers, and more, all driven by an unwavering commitment to bringing the true essence of blockchain technology into people's lives.

To learn more about our talented development team, you can read _Functionland's Team of Ninjas_.

 #### Our Core Team
   - _Mehran_
     - 20+ years of experience in software development
     - .NET guru
     - Managed lots of projects with team size of 20+
     - 5+ years of experience on Azure
   - _Keyvan_
     - MSc. Artificial Intelligence, University of Southampton
     - 10+ years in executive tech positions
     - Open-source veteran
   - _Ehsan_
     - MSc. Electrical and Computer Engineering, University of Colorado Boulder
     - Former Software Lead at L’Oreal
     - UX Architect
   - _Afshin_
     - 20+ years of experience in software development
     - Worked with a variety of technologies: C#, Java, JavaScript, TypeScript, React, Angular, Blazor, Maui, ...
     - Experienced in development for almost every platform: Android, iOS, Windows, macOS, Linux
     - A principal engineer in developing FxFiles
     - A principal engineer in developing TonRich
     - There is literally nothing defined as difficult for Afshin, he will do it!
   - _Maryam_
     - 10+ years of experience in UI/UX
     - Master of CSS and styles
     - Experienced in Blazor
     - The main UI/UX developer of _TonRich_
   - _Hootan_
     - Experienced in Blazor
     - Experienced in CSS and styles
     - Experienced in designing complicated UIs
 
#### Our Previous Projects

   - _FxFiles_
   - _FxFotos_
   - _TonRich_
   - _Ton.Fragment Nuget Package_, A .NET SDK to work with _fragment.com_ auctions on TON

### What is the breakdown of the proposed work, in terms of milestones and/or deadlines?

 - Milestone 0: PoC (Done)
 - Milestone 1: UI
 - Milestone 2: Backend and P2P logic
 - Milestone 3: Connecting to RocketPool APIs (through support from Joe)

### How is the work being tested? Is testing included in the schedule?

To ensure the app's quality, we employ several testing methods:

- **Unit Tests**: Applied to critical sections of the logic.
- **Integration Tests**: Automated tests focusing on the most common scenarios.
- **Android-Specific Tests**: Specialized tests to assess Android-specific code.
- **UAT Tests**: Comprehensive testing conducted by our QA team before each release to ensure smooth functionality from an end-user perspective.

### How will the work be maintained after delivery?

 - This is not only a RocketPool-specific application. Instead, it is a key application in Functionland's ecosystem, and our business is tightly involved with the success of this application.
 - Feature expansion will be pursued through follow-up grants and bounties.

## Payment and Verification

### What is the acceptance criteria?

 - App available on Play Store for download
 - Source code available on GitHub
 - Designs available on Figma

### What is the proposed payment schedule for the grant? How much USD $ and over what period of time is the applicant requesting?

 - Total: 50,000 USD stablecoin
 - Milestone 1 (UI): 50% (**$25,000 at the end of 4th week**)
 - Milestone 2 (Backend and P2P logic): 30% (**$15,000 at the end of 8th week**)
 - Milestone 3 (Connecting to RocketPool SDK): 20% (**$10,000 at the end of 12th week**)

### How will the GMC verify that the work delivered matches the proposed cadence?

Verification will be conducted by assessing the three points outlined in the acceptance criteria at the time of delivery for each milestone.

### What alternatives or options have been considered in order to save costs for the proposed project?

 - We are utilizing cross-platform technologies to lower development costs for various platforms.
 - We have assembled a small, efficient, fully remote team.

## Conflict of Interest
  
### Does the person or persons proposing the grant have any conflicts of interest to disclose? (Please disclose here if you are a member of the GMC or if any member of the GMC would benefit directly financially from the grant).
 - None
   
### Will the recipient of the grant, or any protocol or project in which the recipient has a vested interest (other than Rocket Pool), benefit financially if the grant is successful?```
 - None
