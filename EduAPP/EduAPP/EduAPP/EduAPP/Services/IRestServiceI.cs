using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduAPP.Services
{
	public interface IRestServiceI<Inscription>
	{
		Task<List<Inscription>> RefreshDataAsync ();

		Task SaveTodoInscriAsync(Inscription item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);

		Task<Inscription> GetTodoItemByIdAsync(string id);
	}
}
