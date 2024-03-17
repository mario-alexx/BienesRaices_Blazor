﻿using AutoMapper;
using BienesRaices.Data;
using BienesRaices.Modelos;
using BienesRaices.Modelos.DTO;
using BienesRaices.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace BienesRaices.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public CategoriaRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            _bd = bd;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try
            {
                if(categoriaId == categoriaDTO.Id)
                {
                    // Validación para actualizar
                    Categoria categoria = await _bd.Categoria.FindAsync(categoriaId);
                    Categoria cate = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaActualizada = _bd.Categoria.Update(cate);
                    await _bd.SaveChangesAsync();
                    return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await _bd.Categoria.FindAsync(categoriaId);
            if(categoria != null)
            {
                _bd.Categoria.Remove(categoria);
                return await _bd.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            var categoriaAgregada = await _bd.Categoria.AddAsync(categoria);
            await _bd.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoriaAgregada.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriaDTO = 
                    _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_bd.Categoria);
                return categoriaDTO;
            }   
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                CategoriaDTO categoriaDTO =
                    _mapper.Map<Categoria, CategoriaDTO>(await _bd.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias()
        {
            try
            {
                IEnumerable<DropDownCategoriaDTO> dropDownCategoriaDTO =
                    _mapper.Map<IEnumerable<Categoria>, IEnumerable<DropDownCategoriaDTO>>(_bd.Categoria);
                return dropDownCategoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CategoriaDTO> NombreCategoriaExiste(string nombre)
        {
            try
            {
                CategoriaDTO categoriaDTO = 
                    _mapper.Map<Categoria, CategoriaDTO>(
                        await _bd.Categoria.FirstOrDefaultAsync(
                            c => c.NombreCategoria.ToLower() == nombre.ToLower()));
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
