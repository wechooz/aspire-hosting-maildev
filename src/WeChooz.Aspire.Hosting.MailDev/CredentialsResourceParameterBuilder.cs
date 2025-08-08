using Aspire.Hosting.ApplicationModel;

namespace WeChooz.Aspire.Hosting.MailDev;
/// <summary>
/// Represents a couple of username and password parameter resource builder.
/// </summary>
/// <param name="Username">The parameter resource builder for the username.</param>
/// <param name="Password">The parameter resource builder for the password.</param>
public record CredentialsResourceParameterBuilder(IResourceBuilder<ParameterResource> Username, IResourceBuilder<ParameterResource> Password);
