using FluentMigrator;

namespace VehicleManager.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_USER, "Creating table USER")]
public class Version000001 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Active").AsBoolean().NotNullable()
            .WithColumn("FullName").AsString(255).NotNullable()
            .WithColumn("Cpf").AsString(11).NotNullable().Unique()
            .WithColumn("Email").AsString(255).NotNullable().Unique()
            .WithColumn("Phone").AsString(13).NotNullable().Unique()
            .WithColumn("Password").AsString(2000).NotNullable()
            .WithColumn("RegisterNum").AsString(8).NotNullable().Unique()
            .WithColumn("Role").AsString(100).NotNullable()
            .WithColumn("CnhNum").AsString(9).Nullable().Unique()
            .WithColumn("CnhCategories").AsCustom("TEXT[]").Nullable()
            .WithColumn("ChnDueDate").AsDateTime().Nullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime().Nullable();
    }
}

/*public Guid Id { get; set; }
public string FilialId  { get; set; } = string.Empty;
public bool Active { get; set; } = true;
public string FullName { get; set; } = string.Empty;
public string Cpf { get; set; } = string.Empty;
public string Email { get; set; } = string.Empty;
public string Password { get; set; } = string.Empty;
public string RegisterNum { get; set; } = string.Empty;
public string Role { get; set; } = string.Empty;
public string CnhNum { get; set; } = string.Empty;
public string[] CnhCategories { get; set; } =  Array.Empty<string>();
public string CnhDueDate { get; set; } = string.Empty;
public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        RuleFor(user => user.FullName).NotNull().NotEmpty().WithMessage(ResourceMessagesException.NAME_ERROR);
        RuleFor(user => user.Cpf.Length).NotNull().NotEmpty().Equal(11).WithMessage(ResourceMessagesException.CPF_ERROR);
        RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress().WithMessage(ResourceMessagesException.EMAIL_ERROR);
        RuleFor(user => user.Password.Length).NotNull().NotEmpty().GreaterThanOrEqualTo(8).WithMessage(ResourceMessagesException.PASSWORD_ERROR);
        RuleFor(user => user.Phone.Length).NotNull().NotEmpty().Equal(13).WithMessage(ResourceMessagesException.PHONE_ERROR);
        RuleFor(user => user.Role).NotNull().NotEmpty().WithMessage(ResourceMessagesException.ROLE_ERROR);
        RuleFor(user => user.CnhCategories).NotNull().NotEmpty().WithMessage(ResourceMessagesException.CNH_CATEGORIES_ERROR);
        RuleFor(user => user.CnhDueDate).NotNull().NotEmpty().WithMessage(ResourceMessagesException.CNH_DUE_DATE_ERROR);
        RuleFor(user => user.CnhNum.Length).NotNull().NotEmpty().Equal(9).WithMessage(ResourceMessagesException.CNH_NUM_ERROR);
*/