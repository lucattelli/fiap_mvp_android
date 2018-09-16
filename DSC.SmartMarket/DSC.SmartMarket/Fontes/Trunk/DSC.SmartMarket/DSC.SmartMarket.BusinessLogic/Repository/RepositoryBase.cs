using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
//using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    public abstract class RepositoryBase : UnityBase, IRepositoryBase
    {
        #region Propriedade(s)
        protected Type m_entityType
        { get; set; }

        protected DbContext DbContext
        {
            get
            {
                var resultado = Resolve<DbContext>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        protected ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)DbContext).ObjectContext;
            }
        }

        protected DbSet DbSet
        {
            get
            {
                return DbContext.Set(m_entityType);
            }
        }
        #endregion Propriedade(s)

        #region Construtor(es)
        public RepositoryBase()
        {
            //DefaultMergeOption = MergeOption.NoTracking;
        }

        public RepositoryBase(Type entityType)
            : this()
        {
            //DbContext = dbContext;
            m_entityType = entityType;
        }

        #endregion Construtor(es)

        #region Método(s)
        protected string QualifyEntitySetName(string entitySetName)
        {
            return entitySetName;
            //return string.Concat(Context.DefaultContainerName, ".", entitySetName);
        }

        protected Resultado<DbQuery> Select()
        {
            var resultado = new Resultado<DbQuery>();
            try
            {
                resultado.Sucesso = true;
                resultado.Retorno = DbSet
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado SaveChanges()
        {
            var resultado = new Resultado();
            try
            {
                var qtyAffectedEntities = DbContext.SaveChanges();
                resultado = new Resultado(qtyAffectedEntities > 0);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado InsertEntity(object entity)
        {
            var resultado = new Resultado();
            try
            {

                DbSet.Add(entity);
                DbContext.Entry(entity).State = EntityState.Added;
                resultado = SaveChanges();
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado UpdateEntity(object entity)
        {
            var resultado = new Resultado();
            try
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
                resultado = SaveChanges();
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado DeleteEntity(object entity)
        {
            var resultado = new Resultado();
            try
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Deleted;
                resultado = SaveChanges();
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        /// <summary>
        /// Marca todas as propriedades como modificadas
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="entity">Entidade</param>
        /// <param name="context">Context de Controle de Estado de Persistencia de Entidades</param>
        //private void SetModified(EntityObject entity)
        //{
        //    var stateEntry = Context.ObjectStateManager.GetObjectStateEntry(entity.EntityKey);
        //    var propertyNameList = stateEntry.CurrentValues.DataRecordInfo.FieldMetadata.Select(pn => pn.FieldType.Name);
        //    foreach (var propName in propertyNameList)
        //    {
        //        stateEntry.SetModifiedProperty(propName);
        //    }
        //}
        #endregion Método(s)
    }

    public abstract class RepositoryBase<T> : RepositoryBase, IRepositoryBase<T> where T : class
    {
        #region Proprieadade(s)
        protected new DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }
        protected ObjectSet<T> ObjectSet
        {
            get
            {
                return ObjectContext.CreateObjectSet<T>();
            }
        }
        #endregion Proprieadade(s)

        #region Construtor(es)
        public RepositoryBase()
            : base(typeof(T)) { }

        protected new Resultado<DbQuery<T>> Select()
        {
            var resultado = new Resultado<DbQuery<T>>();
            try
            {
                resultado.Sucesso = true;
                resultado.Retorno = DbSet
                    .AsNoTracking();
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado<IQueryable<T>> Select(int? skip, int? take, string orderBy)
        {
            var resultado = new Resultado<IQueryable<T>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno.AsQueryable();

                    if (!string.IsNullOrEmpty(orderBy))
                    {
                        query = query.OrderBy(orderBy);
                    }
                    else
                    {
                        query = query.OrderBy(GetKeyPropertiesNames());
                    }

                    if (skip.HasValue)
                    {
                        query = query.Skip(skip.Value);
                    }

                    if (take.HasValue)
                    {
                        query = query.Take(take.Value);
                    }

                    resultado = new Resultado<IQueryable<T>>(query);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado InsertEntity(T entity)
        {
            var resultado = new Resultado();
            try
            {
                return base.InsertEntity(entity);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        protected Resultado UpdateEntity(T entity)
        {
            var resultado = new Resultado();
            try
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
                var qtyAffectedEntities = DbContext.SaveChanges();
                resultado = new Resultado(qtyAffectedEntities > 0);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
            //return base.UpdateEntity(entity);
        }

        protected Resultado DeleteEntity(T entity)
        {
            return base.DeleteEntity(entity);
        }

        public virtual Resultado<IList<T>> Selecionar(int? skip, int? take, string orderBy)
        {
            var resultado = new Resultado<IList<T>>();
            try
            {
                var resultadoSelect = Select(skip, take, orderBy);
                resultado += resultadoSelect;
                if (resultadoSelect)
                {
                    var query = resultadoSelect.Retorno;
                    resultado = new Resultado<IList<T>>(query.ToList());
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public virtual Resultado<int> Contar()
        {
            var resultado = new Resultado<int>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno;
                    resultado = new Resultado<int>(query.Count());
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public virtual Resultado Inserir(T entity)
        {
            var resultado = new Resultado();
            try
            {
                resultado = InsertEntity(entity);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public virtual Resultado Atualizar(T entity)
        {
            var resultado = new Resultado();
            try
            {
                resultado = UpdateEntity(entity);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public virtual Resultado Remover(T entity)
        {
            var resultado = new Resultado();
            try
            {
                resultado = DeleteEntity(entity);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
        public string[] GetKeyProperties()
        {
            return ObjectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        }

        public string GetKeyPropertiesNames()
        {
            return String.Join(", ", GetKeyProperties());
        }
        #endregion Construtor(es)
    }
}
