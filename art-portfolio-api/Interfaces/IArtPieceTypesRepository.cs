﻿using art_portfolio_api.Models.DomainModels;

namespace art_portfolio_api.Interfaces
{
    public interface IArtPieceTypesRepository
    {
        Task<List<ArtPieceType>> GetArtPieceTypes();
        Task<ArtPieceType?> GetTypeById(int typeId);
    }
}
