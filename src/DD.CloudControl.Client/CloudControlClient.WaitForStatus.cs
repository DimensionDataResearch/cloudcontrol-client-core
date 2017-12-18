using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
    using Models;
	using Models.Network;
	using Models.Server;

	/// <summary>
	///		The CloudControl API client. 
	/// </summary>
	public partial class CloudControlClient
	{
		/// <summary>
		/// 	Wait for a resource to reach the specified state.
		/// </summary>
		/// <typeparam name="TResource">
		/// 	The resource type.
		/// </typeparam>
		/// <param name="resourceId">
		/// 	The resource Id.
		/// </param>
		/// <param name="targetState">
		/// 	The resource state to wait for.
		/// </param>
		/// <param name="timeout">
		/// 	The amount of time to wait for the resource to reach the target state.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The resource (or <c>null</c> if the resource has been deleted).
		/// </returns>
		/// <exception cref="TimeoutException">
		/// 	The timeout period elapsed before the resource reached the target state.
		/// </exception>
		/// <exception cref="CloudControlException">
		/// 	The target resource was not found with the specified Id, and <paramref name="targetState"/> is not <see cref="ResourceState.Deleted"/>
		/// </exception>
		public async Task<TResource> WaitForState<TResource>(Guid resourceId, ResourceState targetState, TimeSpan timeout, CancellationToken cancellationToken = default(CancellationToken))
			where TResource : Resource
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			Func<Guid, CancellationToken, Task<Resource>> loader = CreateResourceLoader<TResource>();
			Resource resource = await loader(resourceId, cancellationToken);
			while (resource != null && resource.State != targetState)
			{
				if (stopwatch.Elapsed > timeout)
					throw new TimeoutException($"Timed out after waiting {timeout.TotalSeconds} seconds for {typeof(TResource).Name} '{resourceId}' to reach state '{targetState}'.");

				resource = await loader(resourceId, cancellationToken);
			}

			if (resource == null && targetState != ResourceState.Deleted)
				throw new CloudControlException($"{typeof(TResource).Name} not found with Id '{resourceId}'.");

			return (TResource)resource;
		}

		/// <summary>
		/// 	Create a delegate that loads a resource of the specified type by Id.
		/// </summary>
		/// <typeparam name="TResource">
		/// 	The resource type.
		/// </typeparam>
		/// <returns>
		/// 	The loader delegate.
		/// </returns>
		Func<Guid, CancellationToken, Task<Resource>> CreateResourceLoader<TResource>()
			where TResource : Resource
		{
			Type resourceType = typeof(TResource);

			if (resourceType == typeof(NetworkDomain))
				return async (resourceId, cancellationToken) => await GetNetworkDomain(resourceId, cancellationToken);
			else if (resourceType == typeof(Vlan))
				return async (resourceId, cancellationToken) => await GetVlan(resourceId, cancellationToken);
			else if (resourceType == typeof(Server))
				return async (resourceId, cancellationToken) => await GetServer(resourceId, cancellationToken);
			else
				throw new InvalidOperationException($"Unexpected resource type '{typeof(TResource)}'");
		}
	}
}