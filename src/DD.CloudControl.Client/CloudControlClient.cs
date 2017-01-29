using HTTPlease;
using HTTPlease.Formatters;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
    using Models.Directory;

    /// <summary>
    ///		The CloudControl API client. 
    /// </summary>
    public sealed class CloudControlClient
	{
		/// <summary>
        ///		Factory for <see cref="HttpClient"/>s used by the <see cref="CloudControlClient"/>. 
        /// </summary>
		static readonly ClientBuilder HttpClientBuilder = new ClientBuilder();

		/// <summary>
        ///		 The HTTP client used to communicate with the CloudControl API.
        /// </summary>
		readonly HttpClient _httpClient;

		/// <summary>
        ///		Cached user account information. 
        /// </summary>
		UserAccount _account;

		/// <summary>
        ///		Create a new <see cref="CloudControlClient"/>.
        /// </summary>
        /// <param name="httpClient">
		/// 	The HTTP client used to communicate with the CloudControl API.
		/// </param>
		CloudControlClient(HttpClient httpClient)
		{
			if (httpClient == null)
				throw new ArgumentNullException(nameof(httpClient));

			_httpClient = httpClient;
		}

		/// <summary>
        ///		Retrieve the user's account information. 
        /// </summary>
        /// <param name="cancellationToken">
		/// 	An optional <see cref="CancellationToken"/> that can be used to cancel the request.
		/// </param>
        /// <returns>
		/// 	The user account information.
		/// </returns>
		public Task<UserAccount> GetAccount(CancellationToken cancellationToken = default(CancellationToken))
		{
			return GetAccount(false, cancellationToken);
		}

		/// <summary>
        ///		Retrieve the user's account information. 
        /// </summary>
        /// <param name="refresh">
		/// 	Don't use cached account information.
		/// </param>
        /// <param name="cancellationToken">
		/// 	An optional <see cref="CancellationToken"/> that can be used to cancel the request.
		/// </param>
        /// <returns>
		/// 	The user account information.
		/// </returns>
		public async Task<UserAccount> GetAccount(bool refresh, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_account != null && !refresh)
				return _account;

			_account = await
				_httpClient.GetAsync(Requests.Directory.UserAccount, cancellationToken)
				.ReadAsAsync<UserAccount>() // AF: Ugh, no overloads with cancellation support yet. FIXME!
				.ConfigureAwait(false);

			return _account;
		}

		/// <summary>
        ///		Retrieve the user's organisation Id. 
        /// </summary>
        /// <param name="cancellationToken">
		/// 	An optional <see cref="CancellationToken"/> that can be used to cancel the request.
		/// </param>
        /// <returns>
		/// 	The user's organisation Id.
		/// </returns>
		async Task<Guid> GetOrganizationId(CancellationToken cancellationToken = default(CancellationToken))
		{
			UserAccount userAccount = await GetAccount(cancellationToken);

			return userAccount.OrganizationId;
		}

		/// <summary>
        ///		 Create a new <see cref="CloudControlClient"/>.
        /// </summary>
        /// <param name="baseUri">
		/// 	The base URI for the CloudControl API.
		/// </param>
        /// <param name="userName">
		/// 	The CloudControl user name.
		/// </param>
		/// <param name="password">
		/// 	The CloudControl password.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlClient"/>.
		/// </returns>
		public static CloudControlClient Create(Uri baseUri, string userName, string password)
		{
			if (baseUri == null)
				throw new ArgumentNullException(nameof(baseUri));

			return new CloudControlClient(
				HttpClientBuilder.CreateClient(baseUri, new HttpClientHandler
				{
					Credentials = new NetworkCredential(userName, password),
					PreAuthenticate = true
				})
			);
		}
	}
}