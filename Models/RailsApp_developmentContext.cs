using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Rocket_Elevator_Foundation_REST.Models
{
    public partial class RailsApp_developmentContext : DbContext
    {
        public RailsApp_developmentContext()
        {
        }

        public RailsApp_developmentContext(DbContextOptions<RailsApp_developmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<BlazerAudit> BlazerAudits { get; set; }
        public virtual DbSet<BlazerCheck> BlazerChecks { get; set; }
        public virtual DbSet<BlazerDashboard> BlazerDashboards { get; set; }
        public virtual DbSet<BlazerDashboardQuery> BlazerDashboardQueries { get; set; }
        public virtual DbSet<BlazerQuery> BlazerQueries { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingDetail> BuildingDetails { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Elevator> Elevators { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=nuagedoris9;port=3306;database=RailsApp_development;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Entity)
                    .HasMaxLength(255)
                    .HasColumnName("entity");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .HasMaxLength(255)
                    .HasColumnName("number_and_street");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.SuiteAndApartment)
                    .HasMaxLength(255)
                    .HasColumnName("suite_and_apartment");

                entity.Property(e => e.TypeOfAddress)
                    .HasMaxLength(255)
                    .HasColumnName("type_of_address");
            });

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId, "index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CertificateOfOperations)
                    .HasMaxLength(255)
                    .HasColumnName("certificate_of_operations");

                entity.Property(e => e.DateOfCommissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_of_commissioning");

                entity.Property(e => e.DateOfLastInspection)
                    .HasColumnType("date")
                    .HasColumnName("date_of_last_inspection");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BlazerAudit>(entity =>
            {
                entity.ToTable("blazer_audits");

                entity.HasIndex(e => e.QueryId, "index_blazer_audits_on_query_id");

                entity.HasIndex(e => e.UserId, "index_blazer_audits_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(255)
                    .HasColumnName("data_source");

                entity.Property(e => e.QueryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("query_id");

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<BlazerCheck>(entity =>
            {
                entity.ToTable("blazer_checks");

                entity.HasIndex(e => e.CreatorId, "index_blazer_checks_on_creator_id");

                entity.HasIndex(e => e.QueryId, "index_blazer_checks_on_query_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CheckType)
                    .HasMaxLength(255)
                    .HasColumnName("check_type");

                entity.Property(e => e.CreatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("creator_id");

                entity.Property(e => e.Emails).HasColumnName("emails");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.QueryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("query_id");

                entity.Property(e => e.Schedule)
                    .HasMaxLength(255)
                    .HasColumnName("schedule");

                entity.Property(e => e.SlackChannels).HasColumnName("slack_channels");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<BlazerDashboard>(entity =>
            {
                entity.ToTable("blazer_dashboards");

                entity.HasIndex(e => e.CreatorId, "index_blazer_dashboards_on_creator_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("creator_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<BlazerDashboardQuery>(entity =>
            {
                entity.ToTable("blazer_dashboard_queries");

                entity.HasIndex(e => e.DashboardId, "index_blazer_dashboard_queries_on_dashboard_id");

                entity.HasIndex(e => e.QueryId, "index_blazer_dashboard_queries_on_query_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.DashboardId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("dashboard_id");

                entity.Property(e => e.Position)
                    .HasColumnType("int(11)")
                    .HasColumnName("position");

                entity.Property(e => e.QueryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("query_id");
            });

            modelBuilder.Entity<BlazerQuery>(entity =>
            {
                entity.ToTable("blazer_queries");

                entity.HasIndex(e => e.CreatorId, "index_blazer_queries_on_creator_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("creator_id");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(255)
                    .HasColumnName("data_source");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId, "index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmailOfTheAdministratorOfTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("email_of_the_administrator_of_the_building");

                entity.Property(e => e.FullNameOfTheBuildingAdministrator)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_the_building_administrator");

                entity.Property(e => e.FullNameOfTheTechnicalContactForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_the_technical_contact_for_the_building");

                entity.Property(e => e.PhoneNumberOfTheBuildingAdministrator)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number_of_the_building_administrator");

                entity.Property(e => e.TechnicalContactEmailForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("technical_contact_email_for_the_building");

                entity.Property(e => e.TechnicalContactPhoneForTheBuilding)
                    .HasMaxLength(255)
                    .HasColumnName("technical_contact_phone_for_the_building");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<BuildingDetail>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId, "index_building_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.InformationKey)
                    .HasMaxLength(255)
                    .HasColumnName("information_key");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberOfFloorsServed)
                    .HasColumnType("int(11)")
                    .HasColumnName("number_of_floors_served");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId, "index_customers_on_address_id");

                entity.HasIndex(e => e.UserId, "index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.CompanyContactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("company_contact_phone");

                entity.Property(e => e.CompanyDescription).HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.CustomersCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("customers_creation_date");

                entity.Property(e => e.EmailOfCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("email_of_company_contact");

                entity.Property(e => e.FullNameOfCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_company_contact");

                entity.Property(e => e.FullNameOfServiceTechnicalAuthority)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_service_technical_authority");

                entity.Property(e => e.TechnicalAuthorityPhoneForService)
                    .HasMaxLength(255)
                    .HasColumnName("technical_authority_phone_for_service_");

                entity.Property(e => e.TechnicalManagerEmailForService)
                    .HasMaxLength(255)
                    .HasColumnName("technical_manager_email_for_service");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CertificateOfInspection)
                    .HasMaxLength(255)
                    .HasColumnName("certificate_of_inspection");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                entity.Property(e => e.DateOfCommissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_of_commissioning");

                entity.Property(e => e.DateOfLastInspection)
                    .HasColumnType("date")
                    .HasColumnName("date_of_last_inspection");

                entity.Property(e => e.Information)
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("model");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("serial_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.ToTable("interventions");

                entity.HasIndex(e => e.BatteryId, "index_interventions_on_battery_id");

                entity.HasIndex(e => e.BuildingId, "index_interventions_on_building_id");

                entity.HasIndex(e => e.ColumnId, "index_interventions_on_column_id");

                entity.HasIndex(e => e.CustomerId, "index_interventions_on_customer_id");

                entity.HasIndex(e => e.ElevatorId, "index_interventions_on_elevator_id");

                entity.HasIndex(e => e.EmployeeId, "index_interventions_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("author");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ElevatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("elevator_id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Report).HasColumnName("report");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .HasColumnName("result")
                    .HasDefaultValueSql("'Incomplete'");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Pending'");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_268aede6d6");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_911b4ef939");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_d05fb241b3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_4242c0f569");

                entity.HasOne(d => d.Elevator)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ElevatorId)
                    .HasConstraintName("fk_rails_11b5a4bd36");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_2e0d31b7ad");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Attachment)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attachment");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.DepartmentInChargeOfElevators)
                    .HasMaxLength(255)
                    .HasColumnName("department_in_charge_of_elevators");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.FullNameOfContact)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_contact");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.ProjectDescription).HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .HasColumnName("contact_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.InstallationFee)
                    .HasMaxLength(255)
                    .HasColumnName("installation_fee");

                entity.Property(e => e.NumOfActivityHoursPerDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_activity_hours_per_day");

                entity.Property(e => e.NumOfApartments)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_apartments");

                entity.Property(e => e.NumOfBasements)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_basements");

                entity.Property(e => e.NumOfDistinctBusinesses)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_distinct_businesses");

                entity.Property(e => e.NumOfElevatorCages)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_elevator_cages");

                entity.Property(e => e.NumOfFloors)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_floors");

                entity.Property(e => e.NumOfOccupantsPerFloor)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_occupants_per_Floor");

                entity.Property(e => e.NumOfParkingSpots)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_parking_spots");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(255)
                    .HasColumnName("product_line");

                entity.Property(e => e.RequiredColumns)
                    .HasColumnType("int(11)")
                    .HasColumnName("required_columns");

                entity.Property(e => e.RequiredShafts)
                    .HasColumnType("int(11)")
                    .HasColumnName("required_shafts");

                entity.Property(e => e.SubTotal)
                    .HasMaxLength(255)
                    .HasColumnName("sub_total");

                entity.Property(e => e.Total)
                    .HasMaxLength(255)
                    .HasColumnName("total");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EmployeeRole)
                    .HasColumnName("employee_role")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ResetPasswordToken)
                    .HasMaxLength(255)
                    .HasColumnName("reset_password_token");

                entity.Property(e => e.SuperadminRole)
                    .HasColumnName("superadmin_role")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserRole)
                    .HasColumnName("user_role")
                    .HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
