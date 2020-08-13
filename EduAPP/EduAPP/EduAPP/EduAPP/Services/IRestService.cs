using EduAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduAPP.Services
{
	public interface IRestService<Formation>
	{
		Task<List<Formation>> RefreshDataAsync ();

		Task SaveTodoItemAsync (Formation item, bool isNewItem);

		Task SaveInscriAsync(Inscription item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);

		Task<Formation> GetTodoItemByIdAsync(string id);
	}
}
