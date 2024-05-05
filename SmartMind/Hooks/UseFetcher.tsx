import React, { useCallback, useEffect, useReducer } from 'react';

type StateProps<T> = {
  data?: T
  loading: boolean
  error?: Error
}

type Action<T> =
  | { type: 'FETCH_INIT' }
  | { type: 'FETCH_SUCCESS'; payload: T }
  | { type: 'FETCH_FAILURE'; payload: Error }

function dataFetchReducer<T>(state: StateProps<T>, action: Action<T>): StateProps<T> {
  switch (action.type) {
    case 'FETCH_INIT':
      return {
        ...state,
        loading: true,
        error: undefined,
      }
    case 'FETCH_SUCCESS':
      return {
        ...state,
        loading: false,
        data: action.payload,
      }
    case 'FETCH_FAILURE':
      return {
        ...state,
        loading: false,
        error: action.payload,
      }
    default:
      throw new Error('Unhandled action type');
  }
}

function useFetcher<T = unknown>(url: string): StateProps<T> {
  const [state, dispatch] = useReducer(dataFetchReducer, {
    data: undefined,
    loading: true,
    error: undefined,
  })

  const fetchData = useCallback(async () => {
    dispatch({ type: 'FETCH_INIT' })
    try {
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('Erro ao buscar dados');
      }
      const data = await response.json();
      dispatch({ type: 'FETCH_SUCCESS', payload: data as T })
    } catch (error) {
      dispatch({ type: 'FETCH_FAILURE', payload: error })
    }
  }, [url])

  useEffect(() => {
    fetchData()
  }, [fetchData])

  return state as StateProps<T>
}

const UseFetcher = () => {
  const { data, loading, error } = useFetcher<string[]>('URL_DA_API')

  if (loading) return <div>Carregando...</div>
  if (error) return <div>Erro: {error.message}</div>

  return (
    <div>
      {/* Renderize os dados aqui */}
    </div>
  )
}

export default UseFetcher
