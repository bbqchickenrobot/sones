﻿using System;
using System.Collections.Generic;
using System.IO;
using sones.PropertyHyperGraph;

namespace sones.GraphFS
{
    /// <summary>
    /// The interface for all kinds of GraphFS
    /// </summary>
    public interface IGraphFS
    {
        #region Information Methods

        #region IsPersistent

        Boolean IsPersistent { get; }

        #endregion

        #region isMounted

        /// <summary>
        /// Returns true if the file system was mounted correctly
        /// </summary>
        /// <returns>true if the file system was mounted correctly</returns>
        Boolean IsMounted { get; }

        #endregion

        #region GetFileSystemDescription(...)

        /// <summary>
        /// Returns the name or a description of this file system.
        /// </summary>
        /// <returns>The name or a description of this file system</returns>
        String GetFileSystemDescription();

        #endregion

        #region GetNumberOfBytes(...)

        /// <summary>
        /// Returns the size (number of bytes) of this file system
        /// </summary>
        /// <returns>The size (number of bytes) of this file system</returns>
        UInt64 GetNumberOfBytes();

        #endregion

        #region GetNumberOfFreeBytes(...)

        /// <summary>
        /// Returns the number of free bytes of this file system
        /// </summary>
        /// <returns>The number of free bytes of this file system</returns>
        UInt64 GetNumberOfFreeBytes();

        #endregion

        #region GetAccessMode(...)

        /// <summary>
        /// Returns the access mode of this file system
        /// </summary>
        /// <returns>The access mode of this file system</returns>
        FileSystemAccessMode GetAccessMode();

        #endregion

        #endregion

        #region Grow-/Shrink-/Replicate-/WipeFileSystem

        /// <summary>
        /// This enlarges the size of a GraphFS
        /// </summary>
        /// <param name="myNumberOfBytesToAdd">the number of bytes to add to the size of the current file system</param>
        /// <returns>New total number of bytes</returns>
        UInt64 GrowFileSystem(UInt64 myNumberOfBytesToAdd);

        /// <summary>
        /// This reduces the size of a GraphFS
        /// </summary>
        /// <param name="myNumberOfBytesToRemove">the number of bytes to remove from the size of the current file system</param>
        /// <returns>New total number of bytes</returns>
        UInt64 ShrinkFileSystem(UInt64 myNumberOfBytesToRemove);

        /// <summary>
        /// Wipe the file system
        /// </summary>
        void WipeFileSystem();

        /// <summary>
        /// Clones the IGraphFS instance into a stream
        /// </summary>
        /// <returns>A stream that contains a IGraphFS clone</returns>
        Stream CloneFileSystem();

        /// <summary>
        /// Initializes a GraphFS using the stream of a replicated one
        /// </summary>
        void ReplicateFileSystem(Stream myReplicationStream);

        #endregion

        #region Mount-/Remount-/UnmountFileSystem

        /// <summary>
        /// Mounts this file system.
        /// </summary>
        /// <param name="myAccessMode">The file system access mode, e.g. "read-write" or "read-only".</param>
        void MountFileSystem(FileSystemAccessMode myAccessMode);

        /// <summary>
        /// Remounts a file system in order to change its access mode.
        /// </summary>
        /// <param name="myAccessMode">The file system access mode, e.g. "read-write" or "read-only".</param>
        void RemountFileSystem(FileSystemAccessMode myFSAccessMode);

        /// <summary>
        /// Flush all caches and unmount this file system.
        /// </summary>
        void UnmountFileSystem();

        #endregion

        #region Vertex

        /// <summary>
        /// Checks if a vertex exists
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <param name="myEdition">The edition of the vertex  (if left out, the default edition is assumed)</param>
        /// <param name="myVertexRevisionID">The revision id if the vertex (if left out, the latest revision is assumed)</param>
        /// <returns>True if the vertex exists, otherwise false</returns>
        Boolean VertexExists(
            VertexID myVertexID,
            String myEdition = null,
            VertexRevisionID myVertexRevisionID = null);

        /// <summary>
        /// Gets a vertex 
        /// If there is no edition or revision given, the default edition and the latest revision is returned
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <param name="myEdition">The edition of the vertex (if left out, the default edition is returned)</param>
        /// <param name="myVertexRevisionID">The revision id if the vertex (if left out, the latest revision is returned)</param>
        /// <returns>A vertex object or null if there is no such vertex</returns>
        IVertex GetVertex(
            VertexID myVertexID,
            String myEdition = null,
            VertexRevisionID myVertexRevisionID = null);

        /// <summary>
        /// Returns all vertices.
        /// It is possible to filter the vertex type and the vertices itself
        /// </summary>
        /// <param name="myInterestingVertexTypeIDs">Interesting vertex type ids</param>
        /// <param name="myInterestingVertexIDs">Interesting vertex ids</param>
        /// <param name="myInterestingEditionNames">Interesting editions of the vertex</param>
        /// <param name="myInterestingRevisionIDs">Interesting revisions of the vertex</param>
        /// <returns>An IEnumerable of vertices</returns>
        IEnumerable<IVertex> GetAllVertices(
            IEnumerable<UInt64> myInterestingVertexTypeIDs = null,
            IEnumerable<VertexID> myInterestingVertexIDs = null,
            IEnumerable<String> myInterestingEditionNames = null,
            IEnumerable<VertexRevisionID> myInterestingRevisionIDs = null);

        /// <summary>
        /// Returns all editions corresponding to a certain vertex
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <returns>An IEnumerable of editions</returns>
        IEnumerable<String> GetVertexEditions(
            VertexID myVertexID);

        /// <summary>
        /// Returns all revision ids to a certain vertex and edition
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <param name="myInterestingEditions">The interesting vertex editions</param>
        /// <returns>An IEnumerable of VertexRevisionIDs</returns>
        IEnumerable<VertexRevisionID> GetVertexRevisionIDs(
            VertexID myVertexID,
            IEnumerable<String> myInterestingEditions = null);

        /// <summary>
        /// Removes a certain revision of a vertex
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <param name="myInterestingEditions">The interesting editions of the vertex</param>
        /// <param name="myToBeRemovedRevisionIDs">The revisions that should be removed</param>
        /// <returns>True if some revisions have been removed, false otherwise</returns>
        bool RemoveVertexRevision(
            VertexID myVertexID,
            IEnumerable<String> myInterestingEditions = null,
            IEnumerable<VertexRevisionID> myToBeRemovedRevisionIDs = null);

        /// <summary>
        /// Removes a certain edition of a vertex
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <param name="myToBeRemovedEditions">The editions that should be removed</param>
        /// <returns>True if some revisions have been removed, false otherwise</returns>
        bool RemoveVertexEdition(
            VertexID myVertexID,
            IEnumerable<String> myToBeRemovedEditions = null);

        /// <summary>
        /// Removes a vertex entirely
        /// </summary>
        /// <param name="myVertexID">The id of the vertex</param>
        /// <returns>True if a vertex has been erased, false otherwise</returns>
        bool RemoveVertex(
            VertexID myVertexID);

        /// <summary>
        /// Adds a new vertex to the graph fs and returns it
        /// </summary>
        /// <param name="myVertex">The vertex that is going to be inserted</param>
        /// <param name="myEdition">The name of the edition of the new vertex</param>
        /// <param name="myVertexRevisionID">The revision id of the vertex</param>
        bool AddVertex(
            IVertex myVertex,
            String myEdition = null,
            VertexRevisionID myVertexRevisionID = null);

        /// <summary>
        /// Updates a vertex and returns it
        /// </summary>
        /// <param name="myToBeUpdatedVertexID">The vertex id that is going to be updated</param>
        /// <param name="myVertexUpdateDiff">The update for the vertex</param>
        /// <param name="myToBeUpdatedEditions">The editions that should be updated</param>
        /// <param name="myToBeUpdatedRevisionIDs">The revisions that should be updated</param>
        /// <param name="myCreateNewRevision">Determines if it is necessary to create a new revision of the vertex</param>
        IVertex UpdateVertex(
            VertexID myToBeUpdatedVertexID,
            IVertex myVertexUpdateDiff,
            String myToBeUpdatedEditions = null,
            VertexRevisionID myToBeUpdatedRevisionIDs = null,
            Boolean myCreateNewRevision = false);

        #endregion
    }
}