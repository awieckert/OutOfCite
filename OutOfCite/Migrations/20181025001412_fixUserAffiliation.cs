using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutOfCite.Migrations
{
    public partial class fixUserAffiliation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    LinkedIn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    HIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAffiliations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    AffiliationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAffiliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAffiliations_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAffiliations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    AffiliationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: false),
                    Journal = table.Column<string>(nullable: false),
                    JournalImpact = table.Column<double>(nullable: false),
                    Citations = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedArticles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserArticleVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Vote = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArticleVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserArticleVotes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserArticleVotes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Affiliations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Neuroscience" },
                    { 2, "Toxicology" },
                    { 3, "Developmental Biology" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LinkedIn", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 0, "841ebebe-a01c-4552-ac40-6250045c85ed", "admin@admin.com", true, "Admin", "Istrator", "www.linkedin.com/in/admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAsMBUXsx//J+zC6sjG6LDmwpT7Lj84ZYR7QzqXiWlPRBk448mnL/ZgLJ7zp9axQ4w==", null, false, "32ca373c-44e3-4e75-9ef8-e098b15de683", false, "admin@admin.com" },
                    { "41839694-39aa-4bfd-a750-4b342ed1402e", 0, "f5111ca6-adad-466f-9979-4075aa4e4a93", "wiec1369@gmail.com", true, "Adam", "Wieckert", "www.linkedin.com/in/awieckert", false, null, "WIEC1369@GMAIL.COM", "WIEC1369@GMAIL.COM", "AQAAAAEAACcQAAAAEOw+/Seg5Eo58DLnP79S9zVLmAF0tcYkruh/pmYcb0uOPIs0ZBsgONuP3pLr8xPUnA==", null, false, "b8b57b46-f4e6-4455-9289-c5fcd2486404", false, "wiec1369@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "HIndex", "LastName" },
                values: new object[,]
                {
                    { 1, "Antonio", 97, "Damasio" },
                    { 2, "Linda", 26, "Wadiche" },
                    { 3, "Jacques", 17, "Wadiche" },
                    { 4, "David", 66, "Standard" },
                    { 5, "Steven", 31, "Barnes" },
                    { 6, "Steven", 29, "Aller" },
                    { 7, "Mary Ann", 30, "Bjornsti" },
                    { 8, "Phillip", 78, "Beachy" },
                    { 9, "David", 53, "Kingsley" },
                    { 10, "James", 34, "Chen" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Abstract", "AffiliationId", "AuthorId", "Citations", "Journal", "JournalImpact", "Title", "URL" },
                values: new object[,]
                {
                    { 2, "In this brief article I present as a preamble to a developing theory a summary of ideas and evidence discussed elsewhere (see Damasio and Meyer (2008) In: Laureys S, Tononi G (eds) The neurology of consciousness. Elsevier, pp 3–14; Damasio (2010) Self comes to mind. Pantheon). They pertain to the nature of consciousness, to the position and role of consciousness in evolutionary history, and to how the brain constructs consciousness at the level of large-scale systems.", 1, 1, 1.0, "Research and Perspectives in Neurosciences", 3.5, "Thinking about brain and consciousness", "https://link.springer.com/chapter/10.1007/978-3-642-18015-6_3" },
                    { 1, "The dentate gyrus is the entrance of the hippocampal formation and a primary target of excitatory afferents from the entorhinal cortex that carry spatial and sensory information. Mounting evidence suggests that continual adult neurogenesis contributes to appropriate processing of cortical information. The ongoing integration of adult born neurons dynamically modulates connectivity of the network, potentially contributing to dentate cognitive function. Here we review the current understanding of how glutamatergic innervation develops during the progression of adult-born neuron maturation. Summarizing the developmental stages of dentate neurogenesis, we also demonstrate that new neurons at an immature stage of maturation begin to process afferent activity from both medial and lateral entorhinal cortices.", 1, 2, 0.0, "Frontiers in Biology", 1.03, "Development of glutamatergic innervation during maturation of adult-born neurons", "https://link.springer.com/article/10.1007/s11515-015-1362-2" },
                    { 3, "Neurotransmitter spillover represents a form of neural transmission not restricted to morphologically defined synaptic connections. Communication between climbing fibers (CFs) and molecular layer interneurons (MLIs) in the cerebellum is mediated exclusively by glutamate spillover. Here, we show how CF stimulation functionally segregates MLIs based on their location relative to glutamate release. Excitation of MLIs that reside within the domain of spillover diffusion coordinates inhibition of MLIs outside the diffusion limit. CF excitation of MLIs is dependent on extrasynaptic NMDA receptors that enhance the spatial and temporal spread of CF signaling. Activity mediated by functionally segregated MLIs converges onto neighboring Purkinje cells (PCs) to generate a long-lasting biphasic change in inhibition. These data demonstrate how glutamate release from single CFs modulates excitability of neighboring PCs, thus expanding the influence of CFs on cerebellar cortical activity in a manner not predicted by anatomical connectivity.", 1, 3, 24.0, "Neuron", 14.3, "Spillover-Mediated Feedforward Inhibition Functionally Segregates Interneuron Activity", "https://www.sciencedirect.com/science/article/pii/S0896627313003218" },
                    { 4, "Parkinson’s disease (PD) is characterized by intracellular alpha-synuclein (α-syn) inclusions, progressive death of dopaminergic neurons in the substantia nigra pars compacta (SNpc), and activation of the innate and adaptive immune systems. Disruption of immune signaling between the central nervous system (CNS) and periphery, such as through targeting the chemokine receptor type 2 (CCR2) or the major histocompatibility complex II (MHCII), is neuroprotective in rodent models of PD, suggesting a key role for innate and adaptive immunity in disease progression. The purpose of this study was to investigate whether genetic knockout or RNA silencing of the class II transactivator (CIITA), a transcriptional co-activator required for MHCII induction, is effective in reducing the neuroinflammation and neurodegeneration observed in an α-syn mouse model of PD.", 1, 4, 1.0, "Journal of Neuroinflammation", 4.0, "Targeting of the class II transactivator attenuates inflammation and neurodegeneration in an alpha-synuclein model of Parkinson's disease ", "https://jneuroinflammation.biomedcentral.com/articles/10.1186/s12974-018-1286-2" },
                    { 5, "Molecular target therapy for cancer is characterized by unique adverse effects that are not usually observed with cytotoxic chemotherapy. For example, the anaplastic lymphoma kinase (ALK)-tyrosine kinase inhibitor crizotinib causes characteristic visual disturbances, whereas such effects are rare when another ALK-tyrosine kinase inhibitor, alectinib, is used. To elucidate the mechanism responsible for these visual disturbances, the responses to light exhibited by retinal ganglion cells treated with these agents were evaluated using a C57BL6 mouse ex vivo model. Both crizotinib and alectinib changed the firing rate of ON and OFF type retinal ganglion cells. However, the ratio of alectinib-affected cells (15.7%) was significantly lower than that of crizotinib-affected cells (38.6%). Furthermore, these drugs changed the response properties to light stimuli of retinal ganglion cells in some of the affected cells, i.e., OFF cells responded to both ON and OFF stimuli, etc. Finally, the expressions of ALK (a target receptor of both crizotinib and alectinib) and of MET and ROS1 (additional target receptors of crizotinib) were observed at the mRNA level in the retina. Our findings suggest that these drugs might target retinal ganglion cells and that the potency of the drug actions on the light responses of retinal ganglion cells might be responsible for the difference in the frequencies of visual disturbances observed between patients treated with crizotinib and those treated with alectinib. The present experimental system might be useful for screening new molecular target agents prior to their use in clinical trials.", 2, 5, 3.0, "PLoS One", 2.7, "Crizotinib-induced abnormal signal processing in the retina", "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0135521" },
                    { 6, "The Escherichia coli bacteriophage, Qβ (Coliphage Qβ), offers a favorable alternative to M13 for in vitro evolution of displayed peptides and proteins due to high mutagenesis rates in Qβ RNA replication that better simulate the affinity maturation processes of the immune response. We describe a benchtop in vitro evolution system using Qβ display of the VP1 G-H loop peptide of foot-and-mouth disease virus (FMDV). DNA encoding the G-H loop was fused to the A1 minor coat protein of Qβ resulting in a replication-competent hybrid phage that efficiently displayed the FMDV peptide. The surface-localized FMDV VP1 G-H loop cross-reacted with the anti-FMDV monoclonal antibody (mAb) SD6 and was found to decorate the corners of the Qβ icosahedral shell by electron microscopy. Evolution of Qβ-displayed peptides, starting from fully degenerate coding sequences corresponding to the immunodominant region of VP1, allowed rapid in vitro affinity maturation to SD6 mAb. Qβ selected under evolutionary pressure revealed a non-canonical, but essential epitope for mAb SD6 recognition consisting of an Arg-Gly tandem pair. Finally, the selected hybrid phages induced polyclonal antibodies in guinea pigs with good affinity to both FMDV and hybrid Qβ-G-H loop, validating the requirement of the tandem pair epitope. Qβ-display emerges as a novel framework for rapid in vitro evolution with affinity-maturation to molecular targets.", 2, 6, 2.0, "PLoS One", 2.7, "In vitro evolution and affinity-maturation with Coliphage Qβ display", "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0113069" },
                    { 7, "The process of validating an assay for high-throughput screening (HTS) involves identifying sources of variability and developing procedures that minimize the variability at each step in the protocol. The goal is to produce a robust and reproducible assay with good metrics. In all good cell-based assays, this means coefficient of variation (CV) values of less than 10% and a signal window of fivefold or greater. HTS assays are usually evaluated using Z′ factor, which incorporates both standard deviation and signal window. A Z′ factor value of 0.5 or higher is acceptable for HTS. We used a standard HTS validation procedure in developing small interfering RNA (siRNA) screening technology at the HTS center at Southern Research. Initially, our assay performance was similar to published screens, with CV values greater than 10% and Z′ factor values of 0.51 ± 0.16 (average ± standard deviation). After optimizing the siRNA assay, we got CV values averaging 7.2% and a robust Z′ factor value of 0.78 ± 0.06 (average ± standard deviation). We present an overview of the problems encountered in developing this whole-genome siRNA screening program at Southern Research and how equipment optimization led to improved data quality.", 2, 7, 4.0, "	Journal of Laboratory Automation", 2.6, "High-Throughput RNA Interference Screening: Tricks of the Trade", "http://journals.sagepub.com/doi/abs/10.1177/2211068213486786" },
                    { 8, "Suppressor of fused (Su(fu)/Sufu), one of the most conserved components of the Hedgehog (Hh) signaling pathway, binds Ci/Gli transcription factors and impedes activation of target gene expression. In Drosophila, the Su(fu) mutation has a minimal phenotype, and we show here that Ci transcriptional activity in large part is regulated independently of Su(fu) by other pathway components. Mutant mice lacking Sufu in contrast show excessive pathway activity and die as embryos with patterning defects. Here we show that in cultured cells Hh stimulation can augment transcriptional activity of a Gli2 variant lacking Sufu interaction and, surprisingly, that regulation of Hh pathway targets is nearly normal in the neural tube of Sufu-/- mutant embryos that also lack Gli1 function. Some degree of Hh-induced transcriptional activation of Ci/Gli thus can occur independently of Sufu in both flies and mammals. We further note that Sufu loss can also reduce Hh induction of high-threshold neural tube fates, such as floor plate, suggesting a possible positive pathway role for Sufu.", 3, 8, 5.0, "PLoS One", 2.7, "A comparison of Ci/Gli activity as regulated by sufu in drosophila and mammalian hedgehog response", "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0135804" },
                    { 9, "The intestinal epithelium serves critical physiologic functions that are shared among all vertebrates. However, it is unknown how the transcriptional regulatory mechanisms underlying these functions have changed over the course of vertebrate evolution. We generated genome-wide mRNA and accessible chromatin data from adult intestinal epithelial cells (IECs) in zebrafish, stickleback, mouse, and human species to determine if conserved IEC functions are achieved through common transcriptional regulation. We found evidence for substantial common regulation and conservation of gene expression regionally along the length of the intestine from fish to mammals and identified a core set of genes comprising a vertebrate IEC signature. We also identified transcriptional start sites and other putative regulatory regions that are differentially accessible in IECs in all 4 species. Although these sites rarely showed sequence conservation from fish to mammals, surprisingly, they drove highly conserved IEC expression in a zebrafish reporter assay. Common putative transcription factor binding sites (TFBS) found at these sites in multiple species indicate that sequence conservation alone is insufficient to identify much of the functionally conserved IEC regulatory information. Among the rare, highly sequence-conserved, IEC-specific regulatory regions, we discovered an ancient enhancer upstream from her6/HES1 that is active in a distinct population of Notch-positive cells in the intestinal epithelium. Together, these results show how combining accessible chromatin and mRNA datasets with TFBS prediction and in vivo reporter assays can reveal tissue-specific regulatory information conserved across 420 million years of vertebrate evolution. We define an IEC transcriptional regulatory network that is shared between fish and mammals and establish an experimental platform for studying how evolutionarily distilled regulatory information commonly controls IEC development and physiology.", 3, 9, 3.0, "PLoS One Biology", 3.0, "Genomic dissection of conserved transcriptional regulation in intestinal epithelial cells", "https://journals.plos.org/plosbiology/article?id=10.1371/journal.pbio.2002054" },
                    { 10, "The Hedgehog (Hh) pathway is essential for embryonic development and tissue regeneration, and its dysregulation can lead to birth defects and tumorigenesis. Understanding how this signaling mechanism contributes to these processes would benefit from an ability to visualize Hedgehog pathway activity in live organisms, in real time, and with single-cell resolution. We report here the generation of transgenic zebrafish lines that express nuclear-localized mCherry fluorescent protein in a Gli transcription factor-dependent manner. As demonstrated by chemical and genetic perturbations, these lines faithfully report Hedgehog pathway state in individual cells and with high detection sensitivity. They will be valuable tools for studying dynamic Gli-dependent processes in vertebrates and for identifying new chemical and genetic regulators of the Hh pathway.", 3, 10, 2.0, "PLoS One", 2.7, "In vivo imaging of Hedgehog pathway activation with a nuclear fluorescent reporter", "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0103661" }
                });

            migrationBuilder.InsertData(
                table: "UserAffiliations",
                columns: new[] { "Id", "AffiliationId", "ApplicationUserId" },
                values: new object[,]
                {
                    { 1, 1, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966" },
                    { 2, 2, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966" },
                    { 3, 3, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966" },
                    { 4, 1, "41839694-39aa-4bfd-a750-4b342ed1402e" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteArticles",
                columns: new[] { "Id", "ApplicationUserId", "ArticleId" },
                values: new object[,]
                {
                    { 3, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 2 },
                    { 1, "41839694-39aa-4bfd-a750-4b342ed1402e", 1 },
                    { 2, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 7 },
                    { 4, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 10 }
                });

            migrationBuilder.InsertData(
                table: "UserArticleVotes",
                columns: new[] { "Id", "ApplicationUserId", "ArticleId", "Vote" },
                values: new object[,]
                {
                    { 2, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 2, true },
                    { 4, "41839694-39aa-4bfd-a750-4b342ed1402e", 1, true },
                    { 1, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 7, true },
                    { 5, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 8, false },
                    { 3, "35f3b98f-01bb-45ab-93ee-ab6b34a1b966", 10, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AffiliationId",
                table: "Articles",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_ApplicationUserId",
                table: "FavoriteArticles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_ArticleId",
                table: "FavoriteArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedArticles_ApplicationUserId",
                table: "SubmittedArticles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedArticles_ArticleId",
                table: "SubmittedArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAffiliations_AffiliationId",
                table: "UserAffiliations",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAffiliations_ApplicationUserId",
                table: "UserAffiliations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticleVotes_ApplicationUserId",
                table: "UserArticleVotes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticleVotes_ArticleId",
                table: "UserArticleVotes",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteArticles");

            migrationBuilder.DropTable(
                name: "SubmittedArticles");

            migrationBuilder.DropTable(
                name: "UserAffiliations");

            migrationBuilder.DropTable(
                name: "UserArticleVotes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Affiliations");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
