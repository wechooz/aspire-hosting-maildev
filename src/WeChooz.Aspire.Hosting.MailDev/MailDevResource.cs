using Aspire.Hosting.ApplicationModel;

namespace WeChooz.Aspire.Hosting.MailDev;

/// <summary>
/// Resource for the MailDev server.
/// </summary>
public sealed class MailDevResource : ContainerResource, IResourceWithConnectionString
{
    /// <summary>
    /// The name of the SMTP endpoint for the <see cref="MailDevResource"/>.
    /// </summary>
    public const string SmtpEndpointName = "smtp";
    /// <summary>
    /// The name of the HTTP endpoint for the <see cref="MailDevResource"/>.
    /// </summary>
    public const string HttpEndpointName = "http";

    internal CredentialsResourceParameter? Credentials { get; }
    private EndpointReference? _smtpReference;

    internal MailDevResource(string name,
        CredentialsResourceParameter? credentials) : base(name)
    {
        Credentials = credentials;
    }

    private EndpointReference SmtpEndpoint => _smtpReference ??= new(this, SmtpEndpointName);

    /// <summary>
    /// Describes the connection string format string used for this resource.
    /// </summary>
    public ReferenceExpression ConnectionStringExpression
    {
        get
        {
            if (Credentials == null)
            {
                return ReferenceExpression.Create($"smtp://{SmtpEndpoint.Property(EndpointProperty.Host)}:{SmtpEndpoint.Property(EndpointProperty.Port)}");
            }
            return ReferenceExpression.Create(
                $"Endpoint=smtp://{SmtpEndpoint.Property(EndpointProperty.Host)}:{SmtpEndpoint.Property(EndpointProperty.Port)};Username={Credentials.Username};Password={Credentials.Password}"
            );
        }
    }
}
