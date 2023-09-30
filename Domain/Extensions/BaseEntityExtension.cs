using System.Reflection;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Extensions;

public static class BaseEntityExtension
{
    /// <summary>
    /// Получение описания кастомного аттрибута сущности
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetDescription(this Type type)
    {
        var attributes = type.GetCustomAttributes(false);

        dynamic displayAttribute = null;

        if (attributes.Any())
        {
            displayAttribute = attributes.ElementAt(0);
        }

        return displayAttribute?.Description ?? "Unnamed entity";
    }

    /// <summary>
    /// Проверка доступности (неархивности) сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    /// <exception cref="ApplicationException"></exception>
    public static void CheckIsAvailable<TEntity, TKey>(TEntity entity, string id) where TEntity : BaseEntity<TKey>
    {
        var entityTypeName = typeof(TEntity).GetDescription();
        if (entity == null)
        {
            throw new ApplicationException($"'{entityTypeName}' с идентификатором {id} не найден!");
        }

        if (typeof(IHasArchiveAttribute).GetTypeInfo().IsAssignableFrom(typeof(TEntity).GetTypeInfo()))
        {
            var entityWithArchive = entity as IHasArchiveAttribute;
            if (entityWithArchive is { IsArchive: true })
            {
                throw new ApplicationException(
                    $"'{entityTypeName}' с идентификатором {id} находится в архиве!");
            }
        }
    }
}