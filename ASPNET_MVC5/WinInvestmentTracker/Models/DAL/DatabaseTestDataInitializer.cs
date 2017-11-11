using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinInvestmentTracker.Models.DAL
{
    /// <summary>
    /// This class is setup in the web.config to create new data in the database at startup.
    /// Its mentioned in the web.config
    /// </summary>
    public class DatabaseTestDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>    
    {
        //System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
        //System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        /*
         * This method(seed) basically creates and adds our entities to our derived DbContext object,
         * which has a list(DbSet) for each of the entities we want to persist.
         * We basically create those entities here by hand and add them to that list in the DbContext.
         * We then ask the DBContext to SaveChanges() which persists what we've setup to be added to those lists(managed by the DbContext)
         */
        const int MAX = 10;        
        protected override void Seed(ApplicationDbContext db)
        {
            var MAX = 10;
            var factors = new List<InvestmentInfluenceFactor> {
                    new InvestmentInfluenceFactor {
                        Name = "Weather", Description = "The climate will affect the investment.",
                        Influence = "Sunny weather helps, rainy weather doesn't"},
                    new InvestmentInfluenceFactor {
                        Name = "Competiion", Description = "The competition dictates te supply and demand",
                        Influence = "The more cometition the less buiness you get if the competition or on par to you"},
            };
            String[] sampleFactors = new String[]
            {
                    "Healthcare industry performace",
                    "Popularity",
                    "Weather conditions",
                    "Services Industry growth",
                    "Fitness industry growth",
                    "Fitness industry growth",
                    "Current Weight/obiesity trend",
                    "Physical paper services industry",
                    "Woman's desire for beauty",
                    "Trend for exotic cuisine",
                    "Apitite for reading",
                    "Apitite for TV boxsets",
                    "Apitite for Gaming",
            };
            foreach (String each in sampleFactors)
            {
                InvestmentInfluenceFactor f = new InvestmentInfluenceFactor { Name = each, Description = "description about " + each };
                f.Influence = "influenced by " + each;
                factors.Add(f);
            }
            factors.ForEach(f => f.Investments = new List<Investment>());
            factors.ForEach(f => db.Factors.Add(f));
            db.SaveChanges();

            var groups = new List<InvestmentGroup> {
                new InvestmentGroup{ Name = "Transport", Description = "Related to transport", Type = "Sector" },
                new InvestmentGroup{ Name = "Travel/Tourism",Description = "Related to travel and tourism", Type = "Sector" },
                new InvestmentGroup{ Name = "Utilities", Description = "Related to utilities etc.", Type = "Sector" },
                new InvestmentGroup{ Name = "Telecommunications",Description = "Related to telecomms", Type = "Sector" },
                new InvestmentGroup{ Name = "Professional Services/Consulting",Description = "Related to consulting", Type = "Sector" },
                new InvestmentGroup{ Name = "Pharmaceutical/Medical Product",Description = "Medical related", Type = "Sector" },
                new InvestmentGroup{ Name = "Oil/Gas",Description = "Oil and gas related", Type = "Sector" },
                new InvestmentGroup{ Name = "Mining/Metals",Description = "Relating to Mining", Type = "Sector" },
                new InvestmentGroup{ Name = "Manufacturing",Description = "Related to the manufacuring sector", Type = "Sector" },
                new InvestmentGroup{ Name = "IT (Hardware/Software/Services)",Description = "Related to IT sector", Type = "Sector" },
                new InvestmentGroup{ Name = "Investment Banking",Description = "Investment banking related", Type = "Sector" },
                new InvestmentGroup{ Name = "Food and Beverage",Description = "Relatin to food and consumables and drinks", Type = "Sector" },
                new InvestmentGroup{ Name = "Consumer Goods",Description = "Related to consumer goods", Type = "Sector" },
                new InvestmentGroup{ Name = "Agriculture", Description = "Related to farming and growing/producing", Type = "Sector" },
                new InvestmentGroup{ Name = "Unmanned aircraft", Description = "Related to unmanned aircraft", Type = "Vested interest" },
                new InvestmentGroup{ Name = "Personal Goods", Description = "Consumables for ones person", Type = "Sector" },
                new InvestmentGroup{ Name = "South Africa", Description = "Country at the furtherest reach of Africa", Type = "Region" },
                new InvestmentGroup{ Name = "Steel", Description = "Commodity prized for its strength and durability", Type = "Dependency" },
                new InvestmentGroup{ Name = "Software design consulting", Description = "Bespoke advice in software design issues", Type = "Service" },
                new InvestmentGroup{ Name = "Finance", Description = "Economic and financial part of the economy", Type = "Industry" },
                new InvestmentGroup{ Name = "Value Investments", Description = "high current p/e with potential to maintain.", Type = "Investment Type" },
                new InvestmentGroup{ Name = "Growth Investments", Description = "Low p/e with potential to grow", Type = "Investment Type" },
                new InvestmentGroup{ Name = "Momentum Investments", Description = "Fashionalble trends", Type = "Investment Type" },
                new InvestmentGroup{ Name = "Hybrid Investments", Description = "Bit of everything", Type = "Investment Type" },
                new InvestmentGroup{ Name = "Tactical", Description = "carefully considered group", Type = "Investment Strategy" },
                new InvestmentGroup{ Name = "Strategic", Description = "Assets with a strategic goal associated with them", Type = "Investment Strategy" },
                new InvestmentGroup{ Name = "Shares", Description = "Equity in company shares - fractional part owner", Type = "Container" },
                new InvestmentGroup{ Name = "Gold", Description = "ommodity which is valuable when markets are volatile", Type = "Container" },
                new InvestmentGroup{ Name = "Emerging markets", Description = "places like Japan, Turkey, Brazil, Taiwan etc.", Type = "Region" },
            };

            groups.ForEach(g => g.Investments = new List<Investment>());
            groups.ForEach(g => db.Groups.Add(g));

            db.SaveChanges();

            var regions = new List<Region> {
                new Region { Name = "UK ALL COMPANIES", Description = "(Fund Sector)" },
                new Region { Name = "UK SMALLER COMPANIES", Description = "(Fund Sector)"},
                new Region { Name = "JAPAN", Description = "(Fund Sector)"},
                new Region { Name = "JAPANESE SMALLER COMPANIES", Description = "(Fund Sector)"},
                new Region { Name = "ASIA PACIFIC EXCLUDING JAPAN", Description = "(Fund Sector)"},
                new Region { Name = "CHINA / GREATER CHINA SECTOR", Description = "(Fund Sector)"},
                new Region { Name = "NORTH AMERICA", Description = "(Fund Sector)"},
                new Region { Name = "NORTH AMERICAN SMALLER COMPANIES", Description = "(Fund Sector)"},
                new Region { Name = "EUROPE INCLUDING UK", Description = "(Fund Sector)"},
                new Region { Name = "EUROPE EXCLUDING UK", Description = "(Fund Sector)"},
                new Region { Name = "EUROPEAN SMALLER COMPANIES", Description = "(Fund Sector)"},
                new Region { Name = "GLOBAL", Description = "(Fund Sector)"},
                new Region { Name = "GLOBAL EMERGING MARKETS", Description = "(Fund Sector)" }
            };

            regions.ForEach(r => r.Investments = new List<Investment>());
            regions.ForEach(r => db.Regions.Add(r));
            db.SaveChanges();

            var risks = new List<InvestmentRisk> {
                new InvestmentRisk { Name = "Director dismissal", Description = "Financial officer fired due to corruption", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Competition", Description = "Competition from other companies", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Trends/Fashion", Description = "Fashion/popularity of the comodity", Type = Common.RiskType.Company },
                new InvestmentRisk { Name = "Earnings report", Description = "Investor perception based on earnings", Type = Common.RiskType.Company },
            };

            risks.ForEach(r => r.Investments = new List<Investment>());
            risks.ForEach(r => db.Risks.Add(r));
            db.SaveChanges();
            ;
            var investments = new List<Investment>();
            foreach(var investment in MakeRealInvestments())
            {
                investment.InitialInvestment = new Random().Next(100);
                investment.Value = new Random().Next(100);

                investment.Factors = new List<InvestmentInfluenceFactor>();
                investment.Groups = new List<InvestmentGroup>();
                investment.Regions = new List<Region>();
                investment.Risks = new List<InvestmentRisk>();

                var ShouldRandomlyAssignToInvestment = false;
                if (ShouldRandomlyAssignToInvestment)
                {
                    RandomlyAssignToInvestment(factors, groups, regions, risks, investment);
                }
                investments.Add(investment);
            }

            investments.ForEach(inv => db.Investments.Add(inv));
            db.SaveChanges();

            base.Seed(db);
        }

        private static void RandomlyAssignToInvestment(List<InvestmentInfluenceFactor> factors, List<InvestmentGroup> groups, List<Region> regions, List<InvestmentRisk> risks, Investment investment)
        {
            // now randomly assign some of the risks/factors/groups/regions to this investment
            // Get a randome number/sequence of items and then of those sequnece, choose a randome item each value in the sequence
            int gmax = gmax = new Random(DateTime.Now.Millisecond).Next(1, groups.Count);
            for (int g = 0; g < gmax; g++)
            {
                var index = new Random(DateTime.Now.Millisecond).Next(1, groups.Count);
                var group = groups[index];
                group.Investments.Add(investment);
                investment.Groups.Add(group);
            }

            int fmax = new Random(DateTime.Now.Millisecond).Next(1, factors.Count);
            for (int f = 0; f < fmax; f++)
            {
                var index = new Random(f).Next(1, factors.Count);
                var factor = factors[index];
                factor.Investments.Add(investment);
                investment.Factors.Add(factor);
            }

            int rmax = new Random(DateTime.Now.Millisecond).Next(1, risks.Count);
            for (int r = 0; r < rmax; r++)
            {
                int index = new Random(r).Next(1, risks.Count);
                var risk = risks[index];
                risk.Investments.Add(investment);
                investment.Risks.Add(risk);
            }

            int regionmax = new Random(DateTime.Now.Millisecond).Next(1, regions.Count);
            for (int r = 0; r < rmax; r++)
            {
                int index = new Random(r).Next(1, regions.Count);
                var region = regions[index];
                region.Investments.Add(investment);
                investment.Regions.Add(region);
            }
        }

        private static List<Investment> MakeRealInvestments()
        {

            string[,] companies = new string[26,3]
            {            
                // Name, Description, DesirabilityStatement, ValueProposition, Symbol
                { "Akamai technologies Inc", "Akamai Technologies, Inc. is engaged in providing cloud services for delivering, optimizing and securing content and business applications over the Internet. The Company is involved in offering content delivery network (CDN) services. Its services include the delivery of content, applications and software over the Internet, as well as mobile and security solutions. Its solutions include Performance and Security Solutions, Media Delivery Solutions, and Service and Support Solutions. Its Performance and Security Solutions include Web and Mobile Performance Solutions, Cloud Security Solutions, Enterprise Solutions and Network Operator Solutions. The Media Delivery Solutions offerings include Adaptive Delivery solutions, Download Delivery offerings, Infinite Media Acceleration solutions Media Services and Media Analytics. It offers a range of professional services and solutions designed to assist its customers with integrating, configuring, optimizing and managing its core offerings.",""},
                { "Amkor Technolgy Inc", "Amkor Technology, Inc. is a provider of outsourced semiconductor packaging and test services. The Company's packaging and test services are designed to meet application and chip specific requirements, including the type of interconnect technology; size, thickness and electrical, and mechanical and thermal performance. It provides packaging and test services, including semiconductor wafer bump, wafer probe, wafer backgrind, package design, packaging, system-level, and final test and drop shipment services. The Company provides its services to integrated device manufacturers (IDMs), fabless semiconductor companies and contract foundries. IDMs design, manufacture, package and test semiconductors in their own facilities. The Company offers a range of advanced and mainstream packaging and test services. The Company's mainstream packages include leadframe packages, substrate-based wirebond packages and micro-electro-mechanical systems packages.",""},
                { "Attraqt group Ltd", "ATTRAQT Group PLC (ATTRAQT) provides visual merchandising, site search and product recommendation technology. The principal activity of the Company is the development and provision of e-commerce site search, merchandising and product recommendation technology. The Company's Freestyle Merchandising platform provides a range of merchandising disciplines within a single platform. The Company's platform acts as a plugin for a retailer's e-commerce site and provides tools to enable retailers to merchandise. The Company's Freestyle Merchandising enables retailers to control how the products are merchandised through the e-commerce sites, including site search and navigation, product recommendations, category pages, product detail pages, check-out basket, e-mail, order tracking and in-store devices. Over 100 retailers use the ATTRAQT Platform, including various multi-national retailers. The Company's subsidiaries include ATTRAQT Limited and ATTRAQT Inc.",""},
                { "Avon products Inc", "Avon Products, Inc. is a manufacturer and marketer of beauty and related products. The Company's segments include Europe, Middle East & Africa; South Latin America; North Latin America, and Asia Pacific. Its product categories are Beauty, and Fashion and Home. Beauty consists of skincare (which includes personal care), fragrance and color (cosmetics). Fashion and Home consists of fashion jewelry, watches, apparel, footwear, accessories, gift and decorative products, housewares, entertainment and leisure products, children's products and nutritional products. The Company's products include Anew Ultimate Supreme Advanced Performance Creme, Anew Vitale Visible Perfection Blurring Treatment, Big & Multiplied Volume Mascara, Avon True Perfectly Matte Lipstick, Avon Life for Him and for Her Fragrances, Far Away Infinity Fragrance and Avon Nutra Effects body collection with Active Seed Complex. The Company primarily sells its products to the consumer through the direct-selling channel.",""},
                { "Ceres Power Holdings PLC", "Ceres Power Holdings PLC is a United Kingdom-based company, which is a fuel cell technology and engineering company. The Company is engaged in the development and commercialization of its fuel cell technology. The SteelCell, operating at a temperature between 500 and 600 degree Celsius, is a perforated sheet of steel with a special ceramic layer that converts fuel directly into electrical power. Its advanced SteelCell technology uses the existing infrastructure of mains natural gas and is manufactured using commodity materials, such as steel. The Company's SteelCell technology is focused on the automotive sector. The Company's subsidiaries include Ceres Power Ltd, Ceres Intellectual Property Company Ltd and Ceres Power Intermediate Holdings Ltd. Ceres Power Ltd is engaged in the development and commercialization of the Company's fuel cell technology.",""},
                { "Clear Channel Outdoor Holdings Inc", "Clear Channel Outdoor Holdings, Inc. is an outdoor advertising company. The Company provides clients with advertising opportunities through billboards, street furniture displays, transit displays and other out-of-home advertising displays, such as wallscapes and spectaculars. Its segments include Americas outdoor advertising (Americas) and International outdoor advertising (International). The Americas segment consists of operations primarily in the United States, Canada and Latin America. Its Americas assets consist of printed and digital billboards, street furniture and transit displays, airport displays and wallscapes and other spectaculars, which the Company owns or operates under lease management agreements. International segment primarily includes operations in Europe and Asia. The International assets consist of street furniture and transit displays, billboards, mall displays, Smartbike programs, and other spectaculars, which the Company owns or operates under lease agreements.",""},
                { "Coty Inc", "Coty Inc. is a beauty company. The Company operates through four segments: Fragrances, Color Cosmetics, Skin & Body Care and Brazil Acquisition. Its fragrance products include a range of men's and women's products. Its fragrance brands include Calvin Klein, Marc Jacobs, Davidoff, Chloe, Balenciaga, Beyonce, Bottega Veneta, Miu Miu and Roberto Cavalli. Its color cosmetics products include lip, eye, nail and facial color products. The brands in its Color Cosmetics segment include Bourjois, Rimmel, Sally Hansen and OPI. Its skin & body care products include shower gels, deodorants, skin care and sun treatment products. Its skin & body care brands are adidas, Lancaster, philosophy and Playboy. The Company, through Hypermarcas S.A., engages in personal care and beauty business. The Brazil Acquisition segment includes product groupings, such as skin care, nail care, deodorants and hair care products. It operates in the Americas; Europe, the Middle East and Africa (EMEA), and Asia Pacific.",""},
                { "Creighton's PLC", "Creightons plc is engaged in the development, marketing and manufacture of toiletries and fragrances. The Company operates through three business streams: private label business, contract manufacturing business and branded business. Its private label business focuses on private label products for high street retailers and supermarket chains. Its contract manufacturing business develops and manufactures products on behalf of third party brand owners. Its branded business develops, markets, sells and distributes products it has developed and owns the rights to. Its product portfolio includes bath and shower care, haircare, body care, baby and maternity, and fragrances, among others. Its services include market analysis, creative concept generation, product development, brand development, manufacturing and logistics. Its brands include Frizz No More, Volume Pro, Argan Body, Argan Smooth, Keratin Pro, Perfect Hair, Bronze Ambition, Sunshine Blonde, Beautiful Brunette and Just Hair.",""},
                { "ETFS Physical Gold(GBP)", "ETFS Physical Gold (1672) is designed to offer security holders a simple and cost-efficient way to access the gold market by providing a return equivalent to the movements in the gold spot price less the applicable management fee. 1672 is backed by physical allocated gold held by HSBC Bank plc (the custodian). Only metal that conforms with the London Bullion Market Association's (LBMA) rules for Good Delivery can be accepted by the custodian. Each physical bar is segregated, individually identified and allocated.",""},                
                { "Estee lauder Cos Inc", "The Estee Lauder Companies Inc. manufactures and markets skin care, makeup, fragrance and hair care products. The Company offers products, including skin care, makeup, fragrance, hair care and other. The Company operates in beauty products segment. The Company's products are sold in over 150 countries and territories under brand names, including Estee Lauder, Aramis, Clinique, Prescriptives, Lab Series, Origins, Tommy Hilfiger, MAC, Kiton, La Mer, Bobbi Brown, Donna Karan New York, DKNY, Aveda, Jo Malone London, Bumble and bumble, Michael Kors, Darphin, Tom Ford, Smashbox, Ermenegildo Zegna, AERIN, Tory Burch, RODIN olio lusso, Le Labo, Editions de Parfums Frederic Malle, GLAMGLOW, By Kilian, BECCA and Too Faced. Its skin care products include moisturizers, serums, cleansers, toners, body care, exfoliators, acne and oil correctors, facial masks, cleansing devices and sun care products.",""},
                { "Garmin Ltd", "Garmin Ltd. (Garmin) and subsidiaries offer global positioning system (GPS) navigation and wireless devices and applications. The Company operates through five segments. It offers a range of auto navigation products, as well as a range of products and applications designed for the mobile GPS market. It offers products to consumers around the world, including Outdoor Handhelds, Wearable Devices, Golf Devices, and Dog Tracking and Training/Pet Obedience Devices. It offers a range of products designed for use in fitness and activity tracking. Garmin offers a range of products designed for use in fitness and activity tracking. Its aviation business segment is a provider of solutions to aircraft manufacturers, existing aircraft owners and operators, as well as military and government customers and serves a range of aircraft, including transport aircraft, business aviation, general aviation, experimental/light sport, helicopters, optionally piloted vehicles and unmanned aerial vehicles.",""},
                { "Gildan Activewear Inc (US)", "Gildan Activewear Inc. is a manufacturer and marketer of branded basic family apparel, including T-shirts, fleece, sport shirts, underwear, socks, hosiery and shapewear. The Company operates through two segments: Printwear and Branded Apparel. The Printwear segment designs, manufactures, sources, markets, and distributes undecorated activewear products. The Branded Apparel segment designs, manufactures, sources, markets, and distributes branded family apparel, which includes athletic, casual and dress socks, underwear, activewear, sheer hosiery, legwear, and shapewear products, which are sold to retailers in the United States and Canada. The Company sells its products under various brands, including the Gildan, Gold Toe, Anvil, Comfort Colors, American Apparel, Alstyle, Secret, Silks, Kushyfoot, Secret Silky, Therapy Plus, Peds, and MediPeds brands. The Company distributes its products in printwear markets in the United States, Canada, Mexico, Europe, Asia-Pacific and Latin America.",""},
                { "Glanbia PLC", "Glanbia plc (/ˈɡlɒnbiə/)[a] is a global nutrition group with operations in 32 countries. It has leading market positions in sports nutrition, cheese, dairy ingredients, speciality non-dairy ingredients and vitamin and mineral premixes. Glanbia products are sold or distributed in over 130 countries. While Europe and the USA represent the biggest markets, the Group are continuing to expand into the Middle East, Africa, Asia Pacific and Latin America. Glanbia is listed on the Irish and London Stock Exchange (Symbol: GLB). The Group has four segments; Glanbia Nutritionals[2], Performance Nutrition, Dairy Ireland and Joint Ventures & Associates. Including Joint Ventures & Associates, Glanbia has over 6,200 employees worldwide in 32 countries",""},
                { "Inter Parfums", "Inter Parfums, Inc. operates in the fragrance business. The Company manufactures, markets and distributes an array of fragrance and fragrance related products. It operates through two segments: European based operations and United States based operations. The European Operations segment produces and distributes its fragrance products under license agreements with brand owners. It has a portfolio of prestige brands, which include Balmain, Boucheron, Coach, Jimmy Choo, Karl Lagerfeld, Lanvin, Paul Smith, S.T. Dupont, Repetto, Rochas, and Van Cleef & Arpels. Its prestige brand fragrance products are also marketed through its United States operations. These fragrance products are sold under various names, which include Abercrombie & Fitch, Agent Provocateur, Anna Sui, bebe, Dunhill, French Connection, Oscar de la Rent and Shanghai Tang brands. The Company sells its products to department stores, perfumeries, specialty stores, and domestic and international wholesalers and distributors.",""},
                { "Live nation Entertainments Inc", "Live Nation Entertainment, Inc. is a live entertainment company. The Company's businesses consist of the promotion of live events, including ticketing, sponsorship and advertising. Its segments include Concerts, Sponsorship & Advertising, Ticketing and Artist Nation. The Concerts segment is engaged in promotion of live music events in its owned or operated venues and in rented third-party venues; operation and management of music venues; production of music festivals, and creation of associated content. The Ticketing segment is an agency business that sells tickets for events on behalf of its clients. The Artist Nation segment provides management services to music artists in exchange for a commission on the earnings of artists. The Sponsorship & Advertising segment employs sales force that creates and maintains relationships with sponsors to allow businesses to reach customers through its concert, venue, artist relationship and ticketing assets, including advertising on its Websites.",""},
                { "Match Group Inc", "Match Group, Inc., incorporated on February 13, 2009, is a provider of dating products. The Company operates in the Dating segment. The Dating segment consists of all of its dating businesses across the globe. As of March 31, 2017, the Company operated a portfolio of over 45 brands, including Match, Tinder, PlentyOfFish, Meetic, OkCupid, Pairs, Twoo, OurTime, BlackPeopleMeet and LoveScout24, each designed to manage its users' likelihood of finding a romantic connection. As of March 31, 2017, the Company offered its dating products in 42 languages across more than 190 countries.",""},
                { "Nanoco Group PLC", "Nanoco Group PLC is engaged in research, development and manufacturing of heavy-metal free quantum dots and semiconductor nanoparticles for use in display, lighting, solar energy and bio-imaging. The Company's products include Cadmium Free Quantum Dots (CFQD), CFQD quantum dot films, and copper indium gallium di-selenide (CIGS)/copper indium di-selenide/sulfide (CIS) nanoparticles. The Company's CFQD Quantum Dot Films features include ability to vary blue/red ratio per film; managing heat; customizable size and shape available, and designed to work in conjunction with light emitting diode (LED) from a range of 405 nanometers to 455 nanometers as required. The Company's CFQD quantum dots is a platform technology, which has various applications, including flat screen displays, LED lighting and bio-imaging. The Company's CFQD technology operates in display market, which includes televisions, monitors, notebooks, tablets and smartphones.",""},
                { "PureCircle Limited", "PureCircle Limited is a producer of stevia ingredients for the global food and beverage industry. The Company focuses on encouraging healthier diets around the world through the supply of natural ingredients to the global food and beverage industry. The Company has over 40 stevia-related patents. The Company's Zeta Family ingredients consists of the sugar, such as steviol glycosides, including Reb M and Reb D, and allow for the deepest calorie reductions by food and beverage companies. The Company is engaged in production, marketing and distribution of natural sweeteners and flavors. The Company's geographical segments include Asia, Europe and Americas. The Company is also engaged in the production and marketing of stevia leaf extract. The Company involves in plant breeding, which includes Stevia varieties with sweet glycoside content; harvesting, which provides training to farmers; extraction; purification; application, and finished product. It has offices throughout the world.",""},
                { "Revlon Inc", "Revlon, Inc. manufactures, markets and sells around the world a range of beauty and personal care products, including color cosmetics, hair color, hair care and hair treatments, as well as beauty tools, men's grooming products, anti-perspirant deodorants, fragrances, skincare and other beauty care products. The Company operates through four segments: Consumer, which includes cosmetics, hair color and hair care, beauty tools, anti-perspirant deodorants, fragrances and skincare products; Professional, which includes a line of products sold to hair and nail salons, and professional salon distributors, including hair color, shampoos, conditioners, styling products, nail polishes and nail enhancements; Elizabeth Arden, which include Elizabeth Arden, which produces skin care, color cosmetics and fragrances under the Elizabeth Arden brand and Other, which includes the distribution of prestige, designer and celebrity fragrances, cosmetics and skincare products.",""},
                { "Rosslyn Data Technologies", "Rosslyn Data Technologies plc is a United Kingdom-based company, which is engaged in the development and provision of data analytics software. The Company also offers management services. The Company offers RAPid cloud analytics platform, which is designed for decision-makers. RAPid extracts, combines and synchronizes data from number of sources. Its RAPid cloud analytics platform features a suite of self-service tools business users need to automatically extract, integrate, transform and enrich data. The Company offers a range of platforms, such as technology infrastructure, data factory, application center and security. The Company offers various solutions, including big data solutions; finance solutions; human resource solutions; marketing solutions; procurement solutions; sales solutions; systems, applications, products (SAP) solutions, and Microsoft solutions.",""},
                { "Science In Sport Ltd", "Science in Sport plc is engaged in developing, manufacturing and marketing sports nutrition products for professional athletes and sports enthusiasts. The Company's product lines include SiS GO isotonic powders and gels, which are digestible carbohydrates for use during exercise; SiS hydration products, which include SiS GO Hydro tablets and SiS GO Electrolyte powders; SiS GO Bars, which include cereal-based food bars; SiS REGO range, which includes drinks and protein bars for recovery after training, and SiS Protein, which is a whey protein range for lean muscle development. The Company offers products in sport categories, including cycling, running, gym, team sports, triathlon and rowing. The Company's products include SiS GO Energy, SiS REGO Rapid Recovery, SiS WHEY20, SiS Whey Protein, SiS GO Isotonic Energy Gel, SiS Elite Team SKY and GO Energy Bar. The Company's subsidiaries include SiS (Science in Sport) Limited, SiS APAC Pty Limited and Science in Sport Inc.",""},
                { "Steinhoff International Holdings NV (GER)", "Steinhoff International Holdings NV is a Germany-based company that is active in the retail of household goods, apparel, as well as in the automotive industry. The household goods business area includes the retail of furniture, building materials and consumer electronics through the Company's subsidiaries Lipo Einrichtungsmaerkte, Poco and Conforama. In the apparel business area the Company operates, among others, through Pepco and is engaged in retailing of women's, men's and children's wear, shoes, and accessories. The Automotive business area includes car rental activities through its subsidiary Hertz, as well as logistics services, warehousing and distribution, agricultural services, supply chain consulting, mining services and passenger transport through its subsidiary Unitrans. The Company operates as a holding company and is present in Europe, Asia, Africa and Australia.",""},
                { "Tarena International Inc", "Tarena International, Inc. (Tarena International) is a holding company. The Company, through its subsidiaries, provides professional education services, including professional information technology (IT) training courses and non-IT training courses across the People's Republic of China (PRC). It operates through training segment. It offers courses in over 10 IT subjects and approximately three non-IT subjects, and over two kid education programs. It offers an education platform that combines live distance instruction, classroom-based tutoring and online learning modules. It complements the live instruction and tutoring with its learning management system, Tarena Teaching System (TTS). TTS has over five core functions, featuring course content, self-assessment exams, student and teaching staff interaction tools, student management tools and an online student community. In addition, the Company offers Tongcheng and Tongmei featuring IT training courses and non-IT training courses.",""},
                { "Twitter Inc(All Sessions)", "Twitter, Inc. offers products and services for users, advertisers, developers and data partners. The Company's products and services include Twitter, Periscope, Promoted Tweets, Promoted Accounts and Promoted Trends. Its Twitter is a platform for public self-expression and conversation in real time. Periscope broadcasts can also be viewed through Twitter and on desktop or mobile Web browser. Its Promoted Products enable its advertisers to promote their brands, products and services, amplify their visibility and reach, and extend the conversation around their advertising campaigns. Promoted Accounts appear in the same format and place as accounts suggested by its Who to Follow recommendation engine, or in some cases, in Tweets in a user's timeline. Promoted Trends appear at the top of the list of trending topics for an entire day in a particular country or on a global basis. Its MoPub is a mobile-focused advertising exchange. Twitter Audience Platform is an advertising offering.",""},
                { "Under Armour Inc", "Under Armour, Inc. is engaged in the development, marketing and distribution of branded performance apparel, footwear and accessories for men, women and youth. The Company's segments include North America, consisting of the United States and Canada; Europe, the Middle East and Africa (EMEA); Asia-Pacific; Latin America, and Connected Fitness. Its products are sold across the world and worn by athletes at all levels, from youth to professional, on playing fields around the globe, as well as by consumers with active lifestyles. The Company sells its branded apparel, footwear and accessories in North America through its wholesale and direct to consumer channels. As of December 31, 2016, the Company had approximately 151 factory house stores in North America primarily located in outlet centers throughout the United States. In addition, the Company distributes its products in North America through third-party logistics providers with primary locations in Canada, New Jersey and Florida.",""},
                { "Yolo Leisure and technology PLC", "YOLO Leisure and Technology Plc, formerly Pentagon Protection Plc, is an investment company. The Company focuses on opportunities in the travel, technology and leisure sectors. The Company's primary objective is that of securing for the shareholders the possible value consistent with achieving, over time, both capital growth and income for shareholders through developing profitability coupled with dividend payments on a sustainable basis.",""}

            };

            var realInvestments = new List<Investment>();
            for(int i = 0; i < 26;i++)
            {
                realInvestments.Add(new Investment
                {
                    Name = companies[i,0],
                    Description = companies[i, 1],
                    DesirabilityStatement = companies[i, 2],
                    ValueProposition = "",
                    // not needed really
                    InitialInvestment = 0,
                    Symbol = "",
                    Value = 1
                });
            }

            


            return realInvestments;
        }
    }
}